using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Library.Data
{
    public class MyLibrary
    {
        public static List<Book> Books = new();
        public static List<Reader> Readers = new();
        
        public bool CheckISBN(string text)
        {
            bool result = false;
            //check if this book exists
            if (Books.Exists(x => x.rISBN == text))
            {
                //if exists
                result = true;  
            }
            return result;
        }

        public string CheckISBNIsAvailable(string text)
        {
            if (Books.Find(x => x.rISBN == text).rIsAvailable)
            {
                return null;
            }
            else
            {
                return Books.Find(x => x.rISBN == text).rName;
            }
        }

        public void AddBook(string text, string author, string title)
        {
            Book book = new Book(text, title, author,  true);
            Books.Add(book);
            Console.WriteLine("Book with ISBN: {0} Author: {1} Title: {2} added succesfully.", text, author, title,
                Console.BackgroundColor = ConsoleColor.DarkGreen,
                        Console.ForegroundColor = ConsoleColor.Black);
        }

        public void RemoveBook(string isbn)
        {
            Books.RemoveAll(x => x.rISBN == isbn);
        }

        public void LendReturnBook(string book, string reader, bool isLend = true)
        {
            Book localBook = Books.Find(x => x.rISBN == book);
            if (isLend)
            {
                localBook.rIsAvailable = false;
                localBook.rName = reader;
            }
            else
            {
                localBook.rIsAvailable = true;
                localBook.rName = null;
            }
        }

        public void List_Books(string reader = null)
        {
            if (Books is not null &&
                ((Books.Count > 0 && reader is null)
                ||
                (Books.Count(x => x.rName == reader) > 0 && reader is not null))
               )
            {
                Console.WriteLine("Here's a list of books:");

                foreach (Book book in Books)
                {
                    if (book.rIsAvailable && reader is null)
                    {
                        Console.WriteLine("ISBN: {0} Author: {1} Title: {2}", book.rISBN, book.rAuthor, book.rTitle,
                        Console.BackgroundColor = ConsoleColor.DarkCyan,
                        Console.ForegroundColor = ConsoleColor.Black);
                    }
                    else
                    {
                        if (reader is null || (reader is not null && reader == book.rName))
                        {
                            Console.WriteLine("ISBN: {0} Author: {1} Title: {2}, borrowed by {3}", book.rISBN, book.rAuthor, book.rTitle, book.rName,
                            Console.BackgroundColor = ConsoleColor.DarkCyan,
                            Console.ForegroundColor = ConsoleColor.Gray);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("The list of books is empty",
                    Console.BackgroundColor = ConsoleColor.DarkYellow,
                        Console.ForegroundColor = ConsoleColor.Black);
            }
        }

        public bool CheckReader(string text)
        {
            bool result = false;
            if (Readers.Exists(x => x.rName == text))
            {
                result = true;
            }
            return result;
        }

        public int CheckReaderBorrowed(string reader)
        {
            return Books.Count(x => x.rName == reader);

        }
        

        public void EnlistReader(string text)
        {                
                Reader reader = new Reader(text);
                Readers.Add(reader);     
        }

        public void DislistReader(string name)
        {
            Readers.RemoveAll(x => x.rName == name);
        }

        public void List_Readers()
        {
            if (Readers is not null &&
                Readers.Count > 0)
            {
                Console.WriteLine("Here's a list of readers: ");

                foreach (Reader reader in Readers)
                {
                    Console.WriteLine(reader.rName,
                        Console.BackgroundColor = ConsoleColor.DarkCyan,
                        Console.ForegroundColor = ConsoleColor.Black);
                }
            }
            else
            {
                Console.WriteLine("The list of readers is empty",
                    Console.BackgroundColor = ConsoleColor.DarkYellow,
                        Console.ForegroundColor = ConsoleColor.Black);
            }
        }

        public void Load_Data(string jsonFileName, bool isBooks)
        {

            try
            {
                string jsonContent = File.ReadAllText(jsonFileName);
                var jsonSettings = new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.Objects
                    };
                if (isBooks)
                    {
                        Books = JsonConvert.DeserializeObject<List<Book>>(jsonContent, jsonSettings);
                    }
                else
                    {
                        Readers = JsonConvert.DeserializeObject<List<Reader>>(jsonContent, jsonSettings);
                    }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}

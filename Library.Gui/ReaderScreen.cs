using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Enums;
using Library.Data;
using Library.Services;

namespace Library.Gui
{
    public sealed class ReaderScreen : Screen
    {
        private MyLibrary _mylibrary = new();

         #region Public Methods

        public new string LoadDataJson = "Readers.Json";

        public override void Show()
        {
            Console.Clear();
            while (true)
            {
                Console.BackgroundColor = b;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("-- WELCOME TO THE CUSTOMER RELATIONS DEPARTMENT! --");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Enlist reader");
                Console.WriteLine("2. Dislist reader");
                Console.WriteLine("3. List all readers");
                Console.WriteLine("4. Save readers to file");
                Console.WriteLine("5. Load readers from  file");
                Console.WriteLine("6. Show reader's books");
                Console.WriteLine("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    ReaderScreenChoices choice = (ReaderScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case ReaderScreenChoices.Enlist_Reader:
                            Enlist_Reader();
                            break;

                        case ReaderScreenChoices.Dislist_Reader:
                            Dislist_Reader();
                            break;
                        case ReaderScreenChoices.List_Readers:
                            _mylibrary.List_Readers();
                            break;
                        case ReaderScreenChoices.Save_Readers:
                            Console.WriteLine("In construction");
                            break;
                        case ReaderScreenChoices.Load_Readers:
                            Load_Readers();
                            break;
                        case ReaderScreenChoices.Show_Reader_Books:
                            Show_Reader_Books();
                            break;

                        case ReaderScreenChoices.Exit:
                            Console.Clear();
                            Console.BackgroundColor = b;
                            Console.ForegroundColor = dc;
                            return;

                    }
                }
                catch
                {
                    Console.WriteLine("Invalid choice. Try again.",
                        Console.BackgroundColor = b,
                        Console.ForegroundColor = dr);
                }
            }
        }

        #endregion // Public Methods

        private void Enlist_Reader()
        {
            Console.WriteLine("Enter reader's name: ");
            string text = Console.ReadLine();

            if (text is null || text == "")
            {
                throw new ArgumentNullException(nameof(text));
            }
            else 
            {
                if (_mylibrary.CheckReader(text))
                {
                    Console.WriteLine("Reader with name {0} alredy exists.", text,
                        Console.BackgroundColor = dr,
                        Console.ForegroundColor = b);
                }
                else
                {
                    _mylibrary.EnlistReader(text);
                    Console.WriteLine("Reader with name {0} added succesfully.", text,
                        Console.BackgroundColor = dg,
                        Console.ForegroundColor = b);
                }               
            }
        }

        private void Dislist_Reader()
        {
            Console.WriteLine("Enter reader's name to dislist: ");
            string text = Console.ReadLine();

            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            else
            {
                if (_mylibrary.CheckReader(text))
                {

                    int qtyBorrowedBooks = _mylibrary.CheckReaderBorrowed(text);
                    if (qtyBorrowedBooks > 0 )
                    {
                        Console.WriteLine("Reader {0} can not be dislisted, has {1} borrowed book(s).", text, qtyBorrowedBooks,
                        Console.BackgroundColor = dr,
                        Console.ForegroundColor = b);
                    }
                    else 
                    {
                        _mylibrary.DislistReader(text);
                        Console.WriteLine("Reader with name {0} was succesfully dislisted.", text,
                        Console.BackgroundColor = dg,
                        Console.ForegroundColor = b);
                    }
                }
                else
                {
                    Console.WriteLine("Reader with name {0} doesn't exist.", text,
                        Console.BackgroundColor = dr,
                        Console.ForegroundColor = b);
                }
            }
        }

        private void Show_Reader_Books()
        {
            Console.WriteLine("Enter reader's name to show borrowed books: ");
            string text = Console.ReadLine();

            if (text is null || text == "")
            {
                throw new ArgumentNullException(nameof(text));
            }
            else
            {
                if (_mylibrary.CheckReader(text))
                {
                    int qtyBorrowedBooks = _mylibrary.CheckReaderBorrowed(text);
                    if (qtyBorrowedBooks > 0)
                    {
                        _mylibrary.List_Books(text);   
                    }
                    else
                    {
                        Console.WriteLine("Reader with name {0} doesn't have borrowed books.", text,
                        Console.BackgroundColor = dg,
                        Console.ForegroundColor = b);
                    }
                }
                else
                {
                    Console.WriteLine("Reader with name {0} doesn't exist.", text,
                        Console.BackgroundColor = dr,
                        Console.ForegroundColor = b);
                }
            }

        }

        private void Load_Readers()
        {
            _mylibrary.Load_Data(LoadDataJson, false);
        }
    }

}

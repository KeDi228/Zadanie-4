using Library.Data;
using Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Gui
{
    public sealed class BooksScreen : Screen
    {
        private MyLibrary _mylibrary = new();

        #region Public Methods

        public new string LoadDataJson = "Books.Json";
        public override void Show()
        {
            Console.Clear();
            while (true)
            {
                Console.BackgroundColor = b;
                Console.ForegroundColor = c;

                Console.WriteLine("-- WELCOME TO THE BIBLIO DEPARTMENT! --");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Remove a book");
                Console.WriteLine("3. List all books");
                Console.WriteLine("4. Save books to file");
                Console.WriteLine("5. Load books from  file");
                Console.WriteLine("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    BooksScreenChoices choice = (BooksScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case BooksScreenChoices.Add_Book:
                            Add_Book();
                            break;
                        case BooksScreenChoices.Remove_Book:
                            Remove_Book();
                            break;
                        case BooksScreenChoices.List_Books:
                            _mylibrary.List_Books();
                            break;
                        case BooksScreenChoices.Save_Books:
                            Console.WriteLine("In condtruction");
                            break;
                        case BooksScreenChoices.Load_Books:
                            Load_Books();
                            break;

                        case BooksScreenChoices.Exit:
                            Console.Clear();
                            Console.BackgroundColor = b;
                            Console.ForegroundColor = dc;
                            return;

                    }
                }
                catch
                {
                    Console.WriteLine("Invalid choice. Try again.",
                        Console.BackgroundColor = dr,
                        Console.ForegroundColor = b);
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        private void Add_Book()
        {
            Console.WriteLine("Add book by entering It's ISBN: ");
            string text = Console.ReadLine();

            if (text is null || text == "")
            {
                throw new ArgumentNullException(nameof(text));
            }
            else
            {
                if (_mylibrary.CheckISBN(text))
                {
                    Console.WriteLine("Book with ISBN {0} alredy exists.", text,
                        Console.BackgroundColor = dr,
                         Console.ForegroundColor = b);
                }
                else
                {
                    Console.WriteLine("Enter author of the book: ");
                    string? author = Console.ReadLine();
                    if (author is null || author == "") { throw new ArgumentNullException(nameof(author)); }
                    else Console.WriteLine("Enter title of the book: ");
                    string? title = Console.ReadLine();
                    if (title is null || title == "") { throw new ArgumentNullException(nameof(title)); }
                    else _mylibrary.AddBook(text, author, title);
                }

            }
        }

        private void Load_Books()
        {
            _mylibrary.Load_Data(LoadDataJson, true);
        }
        private void Remove_Book()
        {
            Console.WriteLine("Remove book by entering It's ISBN: ");
            string isbn = Console.ReadLine();

            if (!_mylibrary.CheckISBN(isbn))
            {
                Console.WriteLine("No book with ISBN: {0}", isbn,
                    Console.BackgroundColor = dr,
                    Console.ForegroundColor = b);
            }
            else
            {
                string result = _mylibrary.CheckISBNIsAvailable(isbn);
                if (result is null)
                {
                    _mylibrary.RemoveBook(isbn);
                    Console.WriteLine("A book with ISBN {0} was successfully removed", isbn,
                            Console.BackgroundColor = dg,
                            Console.ForegroundColor = b);
                }
                else
                {
                    Console.WriteLine("Book with ISBN {0} was borrowed by reader {1}", isbn, result,
                        Console.BackgroundColor = dr,
                        Console.ForegroundColor = b);
                }
            }
        }

        #endregion //Private Methods
    }

}
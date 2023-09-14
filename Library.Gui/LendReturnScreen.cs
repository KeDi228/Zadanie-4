using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace Library.Gui
{
    public sealed class LendReturnScreen : Screen
    {
        private MyLibrary _mylibrary = new();

        #region Public Methods
        public override void Show()
        {
            Console.Clear();
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("-- WELCOME TO THE OPERATIONS DEPARTMENT! --");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Lend a book");
                Console.WriteLine("2. Return a book");
                Console.WriteLine("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    LendReturnScreenChoices choice = (LendReturnScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case LendReturnScreenChoices.Lend_Book:
                            Lend_Book();
                            break;

                        case LendReturnScreenChoices.Return_Book:
                            Return_Book();
                            break;

                        case LendReturnScreenChoices.Exit:
                            Console.Clear();
                            Console.BackgroundColor = b;
                            Console.ForegroundColor = dc;
                            return;

                    }
                }
                catch
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        #endregion // Public Methods



        #region Private Methods

        private void Lend_Book()
        {
            Console.WriteLine("Enter reader name: ");
            string? text = Console.ReadLine();

            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            else
            {
                if (_mylibrary.CheckReader(text))
                {
                    Console.WriteLine("Enter ISBN of the book: ");
                    string isbn = Console.ReadLine();
                    if (!_mylibrary.CheckISBN(isbn))
                    {
                        Console.WriteLine("No book with ISBN: {0}", isbn);
                    }
                    else
                    {
                        string result = _mylibrary.CheckISBNIsAvailable(isbn);
                        if (result is null)
                        {
                            _mylibrary.LendReturnBook(isbn,text);
                            Console.WriteLine("A book with ISBN {0} was successfully lended to reader {1}", isbn, text,
                                    Console.BackgroundColor = dg,
                                    Console.ForegroundColor = b);
                        }
                        else
                        {
                            Console.WriteLine("Book with ISBN {0} was borrowed by reader {1}", isbn, result);
                        }
                    } 
                }
                else
                {
                    Console.WriteLine("Reader with name {0} doesn't exist.", text);
                }

            }

        }

        private void Return_Book()
        {
            Console.WriteLine("Enter ISBN of the book to return: ");
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
                if (result is not null)
                {
                    _mylibrary.LendReturnBook(isbn, result, false);
                    Console.WriteLine("A book with ISBN {0} was successfully returned from {1}", isbn, result,
                        Console.BackgroundColor = dg,
                        Console.ForegroundColor = b);
                }
                else
                {
                    Console.WriteLine("Book with ISBN {0} was not lended", isbn,
                        Console.BackgroundColor = dr,
                        Console.ForegroundColor = b);
                }
            }
        }

        #endregion //Private Methods
    }
}

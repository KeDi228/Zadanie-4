using Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.Gui
{
    public sealed class MainScreen : Screen
    {
        #region Properties And Ctor

        private MyLibrary _mylibrary = new();

        private BooksScreen _booksScreen;
        private ReaderScreen _readerScreen;
        private LendReturnScreen _lendReturnScreen;

        public MainScreen(
            BooksScreen booksScreen,
            ReaderScreen readerScreen,
            LendReturnScreen lendReturnScreen)
        {
            _booksScreen = booksScreen;
            _readerScreen = readerScreen;
            _lendReturnScreen = lendReturnScreen;
        }
        #endregion Properties And Ctor

        #region Public Methods
        public override void Show()
        {
            Console.Clear();
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Books");
                Console.WriteLine("2. Readers");
                Console.WriteLine("3. Lend/Return book");
                Console.WriteLine("4. Load demo data");
                Console.WriteLine("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case MainScreenChoices.Books:
                            _booksScreen.Show();
                            break;

                        case MainScreenChoices.Readers:
                            _readerScreen.Show();
                            break;

                        case MainScreenChoices.Lend_Return_Book:
                            _lendReturnScreen.Show();
                            break;
                        case MainScreenChoices.Load_Demo_Data:
                            Load_Demo_Data();
                            break;

                        case MainScreenChoices.Exit:
                            Console.WriteLine("Goodbye.");
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

        private void Load_Demo_Data()
        {
            _mylibrary.Load_Data("Books.json", true);
            _mylibrary.Load_Data("Readers.json", false);
            Console.WriteLine("Demo data was loaded succesfully!",
                Console.BackgroundColor = dg,
                Console.ForegroundColor = b);
        }
    }
}

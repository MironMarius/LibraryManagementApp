using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LibraryManagement
{


    public class Program
    {
        public static List<Book> AllBooks = new List<Book>();
        public static List<Book> RentedBooks = new List<Book>();
    
        public static void Main(string[] args)
        {
            DefaultBooks();
            RunMainMenu();
        }
        // Add a book to the library
        public static void AddBook()
        {
            Console.WriteLine("Enter the information of the new book: ");
            Console.WriteLine();
            int option = 1;
            while(option==1)
            {
                Console.Write("Enter Book Name: ");
                string book_name = Console.ReadLine();

                //adding the new book to the list
                foreach (Book book in AllBooks)
                    if (book_name == "")
                        break;
                    else if ((book_name.Length).CompareTo(15) > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Book name is too long");
                        Console.WriteLine("Try again!");
                        Console.ResetColor();
                        AddBook();
                    }

                int book_id = 1;
                foreach (Book book in AllBooks)
                    for (int i = 1; i <= (AllBooks.Count) + 1; i++)
                         book_id = i;
                //Add the data of the new book
                Console.WriteLine();
                Console.Write("Enter Book Price: ");
                int book_price = int.Parse(Console.ReadLine());
                if (book_price > 150 || book_price < 20)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book price must be between 20 and 150");
                    Console.WriteLine("Try again!");
                    Console.ResetColor();
                    AddBook();
                }

                Console.WriteLine();
                Console.Write("Enter ISBN: ");
                string book_isbn = Console.ReadLine();
                if ((book_isbn.Length).CompareTo(13) != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book ISBN must be 13 characters long");
                    Console.WriteLine("Try again!");
                    Console.ResetColor();
                    AddBook();
                }

                Book b = new Book(book_id, book_name, book_isbn, book_price);
                AllBooks.Add(b);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have succesfully added the book to the library!");
                Console.ResetColor();
                Console.WriteLine();
                Menu1();
            }   
        }

        //: Display all the books 
        public static void GetAllBooks()
        {
            DisplayBooks();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press ENTER to proceed to the MENU");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press ANY KEY to EXIT the application");
            Console.ResetColor();
            //take keyboard input
            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.Enter)
            {
                Menu2();
            }
            else
            {
                ExitApp();
            }
        }

        // check book availability
        public static void NumberOfBooks()
        {
            Console.WriteLine("Choose a book to check it's availability!");
            DisplayBooks();
            Console.Write("Enter the NAME of the book you want to choose: ");
            string userInput = Console.ReadLine();
            int nr = 0;
            foreach (Book b in AllBooks)
                if (userInput.Equals(b.Name))
                {
                    nr += 1;
                }
            
            Console.WriteLine("There are {0} {1} books available", nr, userInput);
                Console.WriteLine("");
                Console.ResetColor();

            //take keyboard input
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press ENTER to proceed to the MENU");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press ANY KEY to EXIT the application");
            Console.ResetColor();
            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.Enter)
            {
                Menu3();
            }
            else
            {
                ExitApp();
            }
        }

        //Rent a book function
        public static void RentBook()
        {
            Console.WriteLine();
            DisplayBooks();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the ID of the book that will be rented: ");
            Console.ResetColor();
            int inputId = int.Parse(Console.ReadLine());

            foreach(Book b in AllBooks.ToList())
                if(inputId == b.Id )
                {
                    RentedBooks.Add(b);
                    AllBooks.Remove(b);
                }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Books that are currently on rental: ");
            Console.WriteLine();
            Console.ResetColor();

            foreach (Book q in RentedBooks)
            { 
                Console.Write("Book ID: ");
                Console.WriteLine(q.Id);
                Console.Write("Book name: ");
                Console.WriteLine(q.Name);
                Console.Write("ISBN: ");
                Console.WriteLine(q.Isbn);
                Console.Write("Rental price: {0} RON ", q.Price);
                Console.WriteLine(" ");
            }

            //take keyboard input
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press ENTER to proceed to the MENU");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press ANY KEY to EXIT the application");
            Console.ResetColor();
            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.Enter)
            {
                Menu4();
            }
            else
            {
                ExitApp();
            }
        }

        public static void RunMainMenu() 
        {
            string prompt = "Use the arrow keys to cycle through options and press Enter to select the option";
            string[] options = { "Add a new book", "Display all the books in the library", "Check the availability of a book", "Rent a book","Return a book","Exit app" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch(selectedIndex)
            {
                case 0:
                    Clear();
                    AddBook();
                    break;
                case 1:
                    Clear();
                    GetAllBooks();
                    break;
                case 2:
                    Clear();
                    NumberOfBooks();
                    break;
                case 3:
                    Clear();
                    RentBook();
                    break;
                case 4:
                    Clear();
                    BookRental.ReturnBook();
                    break;
                case 5:
                    ExitApp();
                    break;
            }
        }

        public static void Menu1()
        {
            string prompt = "Use the arrow keys to cycle through options and press Enter to select the option";
            string[] options = { "Add another book", "Return to Main Menu"};
            Menu secondaryMenu = new Menu(prompt, options);
            int selectedIndex = secondaryMenu.Run();

            switch(selectedIndex)
            {
                case 0:
                    AddBook();
                    break;
                case 1:
                    RunMainMenu();
                    break;
            }
        }

        public static void Menu2()
        {
            string prompt = "Use the arrow keys to cycle through options and press Enter to select the option";
            string[] options = { "Display all books", "Return to Main Menu" };
            Menu secondaryMenu = new Menu(prompt, options);
            int selectedIndex = secondaryMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    GetAllBooks();
                    break;
                case 1:
                    RunMainMenu();
                    break;
            }
        }

        public static void Menu3()
        {
            string prompt = "Use the arrow keys to cycle through options and press Enter to select the option";
            string[] options = { "Check the availabilty of another book", "Return to Main Menu" };
            Menu secondaryMenu = new Menu(prompt, options);
            int selectedIndex = secondaryMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    NumberOfBooks();
                    break;
                case 1:
                    RunMainMenu();
                    break;
            }

        }

        public static void Menu4()
        {
            string prompt = "Use the arrow keys to cycle through options and press Enter to select the option";
            string[] options = { "Rent another book", "Return to Main Menu" };
            Menu secondaryMenu = new Menu(prompt, options);
            int selectedIndex = secondaryMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RentBook();
                    break;
                case 1:
                    RunMainMenu();
                    break;
            }
        }

        public static void Menu5()
        {
            string prompt = "Use the arrow keys to cycle through options and press Enter to select the option";
            string[] options = { "Return another book", "Return to Main Menu" };
            Menu secondaryMenu = new Menu(prompt, options);
            int selectedIndex = secondaryMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    BookRental.ReturnBook();
                    break;
                case 1:
                    RunMainMenu();
                    break;
            }
        }

        public static void ExitApp()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        //Adding some default books to the library
        public static void DefaultBooks()
        {
            Book book1 = new Book
            {
                Id = 1,
                Name = "Tarzan",
                Isbn = "9786064402547",
                Price = 50
            };

            var book2 = new Book
            {
                Id = 2,
                Name = "Poetry",
                Isbn = "5436461214544",
                Price = 30
            };

            var book3 = new Book
            {
                Id = 3,
                Name = "Essentialism",
                Isbn = "6852314402543",
                Price = 70
            };

            var book4 = new Book
            {
                Id = 4,
                Name = "Winnetou",
                Isbn = "3428664102231",
                Price = 40
            };

            AllBooks.Add(book1);
            AllBooks.Add(book2);
            AllBooks.Add(book3);
            AllBooks.Add(book4);
        }

        public static void DisplayBooks()
        {
            //Display books that are in the library
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Books that are available in the library: ");
            Console.WriteLine();
            Console.ResetColor();
            foreach (Book b in AllBooks)
            {
                Console.Write("Book ID: ");
                Console.WriteLine(b.Id);
                Console.Write("Book name: ");
                Console.WriteLine(b.Name);
                Console.Write("ISBN: ");
                Console.WriteLine(b.Isbn);
                Console.Write("Rental price: {0} RON ", b.Price);
                Console.WriteLine(" ");
            }

            //Display books that are rented
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Books that are rented: ");
            Console.WriteLine();
            Console.ResetColor();
            foreach (Book r in RentedBooks)
            {
                Console.Write("Book ID: ");
                Console.WriteLine(r.Id);
                Console.Write("Book name: ");
                Console.WriteLine(r.Name);
                Console.Write("ISBN: ");
                Console.WriteLine(r.Isbn);
                Console.Write("Rental price: {0} RON ", r.Price);
                Console.WriteLine(" ");
            }
        }
    }
}

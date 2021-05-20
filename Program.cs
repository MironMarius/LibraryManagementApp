using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LibraryManagement
{
   

    class Program
    {
        public static List<Book> AllBooks = new List<Book>();
        public static List<Book> RentedBooks = new List<Book>();


        static void Main(string[] args)
        {
            DefaultBooks();
            AppInfo();
            RunMainMenu();
            

        }
     
        //Menu option 1: Add a book to the library
        public static void AddBook()
        {
            Console.WriteLine("Enter the information of the new book: ");
            Console.WriteLine();
            int option = 1;
            while(option==1)
            {
                
                Console.WriteLine();
                Console.Write("Enter Book Name: ");
                string new_book = Console.ReadLine();


                foreach (Book book in AllBooks)
                    if (new_book == "")
                        break;
                    else if ((new_book.Length).CompareTo(10) > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Book name is too long");
                        Console.ResetColor();
                        Menu1();
                        //ChooseAction();
                        //UserInput();
                    }

                        Console.WriteLine();
                int book_id = 1;
                foreach (Book book in AllBooks)
                    for (int i = 1; i <= (AllBooks.Count) + 1; i++)
                         book_id = i;
                //Add the data of the new book
                Console.WriteLine();
                Console.Write("Enter Book Price: ");
                int book_price = int.Parse(Console.ReadLine());
                if (book_price > 100 || book_price < 20)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book price must be between 20 and 100");
                    Console.ResetColor();
                    Menu1();
                   
                }


                Console.WriteLine();
                Console.Write("Enter ISBN: ");
                string book_isbn = Console.ReadLine();
                if ((book_isbn.Length).CompareTo(13) != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book ISBN must be 13 characters long");
                    Console.ResetColor();
                    Menu1();
                  
                }


                Book b = new Book(book_id, new_book, book_isbn, book_price);
                AllBooks.Add(b);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have succesfully added the book to the library!");
                Console.ResetColor();
                Console.WriteLine();
                Menu1();
              
            }   
        }

        //Menu options 2: Display all the books 
        public static void GetAllBooks()
        {
            //Display books that are in the library
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Books in the library: ");
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
                Console.Write("Rental price: ");
                Console.WriteLine(b.Price);
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
                Console.Write("Rental price: ");
                Console.WriteLine(r.Price);
                Console.WriteLine(" ");
            }
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
        //Display menu option 3: check book availability
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

            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.Write("Menu:");
            //Console.WriteLine("Check for another book.(Type 1)");
            //Console.WriteLine("Return to the Main menu.(Type 2)");
            //Console.ResetColor();
            //int option = int.Parse(Console.ReadLine());
            //if (option == 2)
            //{
            //   ChooseAction();
            //   UserInput();
            //}
            //else if (option == 1)
            // NumberOfBooks();

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
                Console.Write("Rental price: ");
                Console.WriteLine(q.Price);
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

        public static void ReturnBook()
        {
            
            Console.WriteLine();
            DisplayBooks();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the ID of the book that will be returned: ");
            Console.ResetColor();
            int inputId = int.Parse(Console.ReadLine());
            foreach(Book r in RentedBooks.ToList())
                if(inputId==r.Id)
                        {
                    Console.WriteLine("The book {0} has {1} rent to be paid", r.Name, RentDue(r));
                            AllBooks.Add(r);
                            RentedBooks.Remove(r);
                        }
            
            Console.WriteLine();

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
                Menu5();

            }
            else
            {
                ExitApp();
            }

        }
        //Calculates the penalty for the overdue return time
        public static decimal RentDue(Book book)
        {
            Console.Write("Enter the number of days since the book has been borrowed: ");
            decimal DaysSinceBorrowed = decimal.Parse(Console.ReadLine());
            if(DaysSinceBorrowed > 14)
                DaysSinceBorrowed -= 14;

            return (book.Price + ((book.Price*DaysSinceBorrowed)/100));

          
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
                    ReturnBook();
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
                    ReturnBook();
                    break;
                case 1:
                    RunMainMenu();
                    break;
            }
        }

        static void ExitApp()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        //Retrieve input from user
        static void UserInput()
        {
            string input = Console.ReadLine();
            Console.WriteLine("");

            if (input.Equals("1"))
            {
                AddBook();
            }
            else if (input.Equals("2"))
            {
                GetAllBooks();
            }
            else if( input.Equals("3"))
            {
                NumberOfBooks();
            }
            else if(input.Equals("4"))
            {
                Console.WriteLine("MENU: ");
                Console.WriteLine("Rent a book. (Type 1)");
                Console.WriteLine("Return a book. (Type 2)");
                Console.Write("Choose option: ");
                int rentOrReturn = int.Parse(Console.ReadLine());
                if (rentOrReturn == 1)
                    RentBook();
                else if (rentOrReturn == 2)
                    ReturnBook();
                else Console.WriteLine("Invalid option!");
            }
              
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Books that are in the library: ");
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
                Console.Write("Rental price: ");
                Console.WriteLine(b.Price);
                Console.WriteLine(" ");
            }
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
                Console.Write("Rental price: ");
                Console.WriteLine(r.Price);
                Console.WriteLine(" ");
            }
        }

        //App introduction
        static void AppInfo()
        {
            string appName = "Welcome to the virtual library!";
            string appVersion = "1.0.0";
            string appAuthor = "Miron Marius";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}: version {1} made by {2}", appName, appVersion, appAuthor);
            Console.ResetColor();
        }

        //Lets user choose the action they want to perform
        static void ChooseAction()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ");
            Console.WriteLine("MAIN MENU:");
            Console.WriteLine("Enter a new book.(Type 1)");
            Console.WriteLine("Display all the books in the library.(Type 2)");
            Console.WriteLine("Check the availabilty of a book.(Type 3)");
            Console.WriteLine("Rent or return a book.(Type 4)");
            Console.WriteLine(" ");
            Console.Write("Enter your action here:");
            Console.ResetColor();


        }

    }


}

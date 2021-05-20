using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
   

    class Program
    {
        public static List<Book> AllBooks = new List<Book>();
        public static List<Book> RentedBooks = new List<Book>();
        

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
        //Display all the books 
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
            ChooseAction();
            UserInput();
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
        //Add a book to the library
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
                        ChooseAction();
                        UserInput();
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
                    ChooseAction();
                    UserInput();
                }


                Console.WriteLine();
                Console.Write("Enter ISBN: ");
                string book_isbn = Console.ReadLine();
                if ((book_isbn.Length).CompareTo(13) != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book ISBN must be 13 characters long");
                    Console.ResetColor();
                    ChooseAction();
                    UserInput();
                }


                Book b = new Book(book_id, new_book, book_isbn, book_price);
                AllBooks.Add(b);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have succesfully added the book to the library!");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Menu:");
                Console.WriteLine("Add another book.(Type 1)");
                Console.WriteLine("Return to the Main menu.(Type 2)");
                Console.ResetColor();
                option = int.Parse(Console.ReadLine());
                if (option == 2)
                {
                    ChooseAction();
                    UserInput();
                }
                else if (option == 1)
                    continue;
            }   
        }

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
            
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Menu:");
            Console.WriteLine("Check for another book.(Type 1)");
            Console.WriteLine("Return to the Main menu.(Type 2)");
            Console.ResetColor();
            int option = int.Parse(Console.ReadLine());
            if (option == 2)
            {
                ChooseAction();
                UserInput();
            }
            else if (option == 1)
                NumberOfBooks();

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

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Menu:");
            Console.WriteLine("Rent another book.(Type 1)");
            Console.WriteLine("Return to the Main menu.(Type 2)");
            Console.ResetColor();
            int option = int.Parse(Console.ReadLine());
            if (option == 2)
            {
                ChooseAction();
                UserInput();
            }
            else if (option == 1)
                RentBook();
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
                    foreach(Book b in AllBooks)
                        if(r.Name==b.Name)
                        {
                            AllBooks.Add(r);
                            RentedBooks.Remove(r);
                        }
            DisplayBooks();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Menu:");
            Console.WriteLine("Return another book.(Type 1)");
            Console.WriteLine("Return to the Main menu.(Type 2)");
            Console.ResetColor();
            int option = int.Parse(Console.ReadLine());
            if (option == 2)
            {
                ChooseAction();
                UserInput();
            }
            else if (option == 1)
                ReturnBook();

        }

        public static void RentDue()
        {

        }


        static void Main(string[] args)
        {
            DefaultBooks();
            AppInfo();
            ChooseAction();
            UserInput();
            
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

        //Let's user choose the action they want to perform
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
    }
   

}

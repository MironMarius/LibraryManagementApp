using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LibraryManagement
{
    public class BookRental
    {
        //Calculates the penalty for the overdue return time
        public static decimal RentDue(Book book)
        {
             decimal days = decimal.Parse(Console.ReadLine());
            if (days > 14)
            {
                days -= 14;
                return (book.Price + ((book.Price * days) / 100));
            }
            else if (days <= 14)
                return book.Price;
            return book.Price;
        }

        //Return book to the library
        public static void ReturnBook()
        {
            Console.WriteLine();
            Program.DisplayBooks();
            Console.Write("Enter the ID of the book that will be returned: ");
            int inputId = int.Parse(Console.ReadLine());

            foreach (Book r in Program.RentedBooks.ToList())
                if (inputId == r.Id)
                {
                    Console.Write("Enter the number of days since the book has been borrowed: ");
                    decimal rentDue = RentDue(r);

                    if (rentDue > r.Price)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The 14 days term has been surpassed, added {0} RON penalty to the initial price of {1} RON for a total of {2} RON", rentDue - r.Price, r.Price, rentDue);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The book was returned in time, pay due is {0}", r.Price);
                        Console.ResetColor();
                    }

                    Program.AllBooks.Add(r);
                    Program.RentedBooks.Remove(r);
                }

            Console.WriteLine();

            //take keyboard input
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press ENTER to proceed to the MENU");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press ANY KEY to EXIT the application");
            Console.ResetColor();
            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.Enter)
            {
                Program.Menu5();
            }
            else
            {
                Program.ExitApp();
            }
        }
    }
}

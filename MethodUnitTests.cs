using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{
    //separate class for methods that are Unit Tested because I couldn't manage to retrieve user input for the tests, this method doesn't take user input
    public class MethodUnitTests
    {
        public static decimal RentDueUnitTest(Book book)
        {
            decimal days = 14;
            if (days > 14)
            {
                days -= 14;
                return (book.Price + ((book.Price * days) / 100));
            }
            else if (days <= 14)
                return book.Price;
            return book.Price;
        }
    }
}

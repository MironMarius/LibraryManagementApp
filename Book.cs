using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public decimal Price { get; set; }
        
        public Book()
        {

        }

        public Book(int id, string name, string isbn, decimal price)
        {
            Id = id;
            Name = name;
            Isbn = isbn;
            Price = price;
        }
    }
}

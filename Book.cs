using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    //Book class
    public class Book
    {

        
        public int Id { get; set; }
        [Required(ErrorMessage ="The book name is required")]
        [MaxLength(10)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The book ISBN is required")]
        public string Isbn { get; set; }
        [Required(ErrorMessage = "The book price is required")]
        [MinLength(2)]
        [MaxLength(3)]
        public int Price { get; set; }
        

        //Book constructors
        public Book()
        {

        }

        public Book(int id, string name, string isbn, int price)
        {
            Id = id;
            Name = name;
            Isbn = isbn;
            Price = price;
            
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_Book.Models
{
    public class BooksView
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfPublication { get; set; }
        public Guid AuthorsId { get; set; }
        public AuthorsView Authors { get; set; }               
        
    }
}
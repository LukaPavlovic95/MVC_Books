using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_Book.Models
{
    public class AuthorsView
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<BooksView> Books { get; set; }
    }
}
using Service.ModelsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Books : IBooks
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfPublication { get; set; }
        public Guid AuthorsId { get; set; }
        public IAuthors Authors { get; set; }
    }
}

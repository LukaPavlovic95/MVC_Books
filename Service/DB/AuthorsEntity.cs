using Service.ModelsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DB
{
    public class AuthorsEntity
    {
         
        public Guid ID { get; set; }
        public string Name { get; set; }
        public ICollection<BooksEntity> Books { get; set; }
    
    }
}

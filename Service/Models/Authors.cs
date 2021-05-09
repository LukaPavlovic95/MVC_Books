using Service.ModelsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Authors : IAuthors
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public ICollection<IBooks> Books { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ModelsInterface
{
    public interface IBooks
    {
        Guid ID { get; set; }      
        string Name { get; set; }
        DateTime DateOfPublication { get; set; }
        Guid AuthorsId { get; set; }
        IAuthors Authors { get; set; }
    }
}

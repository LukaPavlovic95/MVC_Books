using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ModelsInterface
{
    public interface IAuthors
    {
        Guid ID { get; set; }
        string Name { get; set; }
        ICollection<IBooks> Books { get; set; }
    }
}

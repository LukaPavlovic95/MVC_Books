using Service.Models;
using Service.ModelsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterface
{
    public interface IBooksService
    {
        Task<IEnumerable<IBooks>> GetBooksAsync();
        Task<IBooks> Edit(IBooks book);
        Task<IBooks> GetOneBookAsync(Guid id);
        Task<bool> Update(IBooks book);
        Task<bool> Delete(Guid id);
    }
}

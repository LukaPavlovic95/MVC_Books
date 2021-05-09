using Service.Models;
using Service.ModelsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterface
{
    public interface IAuthorsService
    {
        Task<IEnumerable<IAuthors>> GetAuthorsAsync();
        Task<IAuthors> Edit(IAuthors author);
        Task<IAuthors> GetOneAuthorAsync(Guid id);
        Task<bool> Update(IAuthors author);
        Task<bool> Delete(Guid id);
    }
}

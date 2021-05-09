using Service.ModelsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterface
{
    public interface ILoginService
    {
        Task<string> Login(ILogin regInfo);
    }
}

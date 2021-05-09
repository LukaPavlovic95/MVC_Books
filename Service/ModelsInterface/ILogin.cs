using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ModelsInterface
{
    public interface ILogin
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}

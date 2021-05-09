using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ModelsInterface
{
    public interface IRegister
    {
        int Id { get; set; }       
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
    }
}

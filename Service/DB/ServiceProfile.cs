using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Service.DB;
using Service.ModelsInterface;

namespace Service
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<AuthorsEntity, IAuthors>().ReverseMap();
            CreateMap<BooksEntity, IBooks>().ReverseMap();
            CreateMap<AccountEntity, IRegister>().ReverseMap();
        }
    }    
}

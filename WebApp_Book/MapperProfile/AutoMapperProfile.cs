using AutoMapper;
using Service.Models;
using Service.ModelsInterface;
using WebApp_Book.Models;

namespace WebApp_Book.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BooksView,IBooks>()
                   .ReverseMap();

            CreateMap<AuthorsView,IAuthors>()
                    .ReverseMap();
            CreateMap<LoginView, ILogin>()
                   .ReverseMap();
            CreateMap<RegisterView, IRegister>()
                   .ReverseMap();
        }
    }
}
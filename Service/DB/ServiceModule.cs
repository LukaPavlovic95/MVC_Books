using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Service.DB;
using Service.Models;
using Service.ModelsInterface;
using Service.Service;
using Service.ServiceInterface;

namespace Service
{
    public class ServiceModule : Module
    {
        public static void ConfigureServiceModule(ContainerBuilder builder)
        {
            builder.RegisterType<Authors>().As<IAuthors>();
            builder.RegisterType<Books>().As<IBooks>();
            builder.RegisterType<Register>().As<IRegister>();
            builder.RegisterType<Login>().As<ILogin>();
            builder.RegisterType<AuthorsService>().As<IAuthorsService>();
            builder.RegisterType<BooksService>().As<IBooksService>();
            builder.RegisterType<RegisterService>().As<IRegisterService>();
            builder.RegisterType<LoginService>().As<ILoginService>();
            builder.RegisterAssemblyTypes(typeof(ServiceModule).Assembly).As<ServiceProfile>();
        }

    }
}

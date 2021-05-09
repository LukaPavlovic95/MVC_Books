using Autofac;
using Service;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Service.DB;
using WebApp_Book.MapperProfile;
using AutoMapper.Configuration;

namespace WebApp_Book.App_Start
{
    public class AutofacConfig
    {
        private static IContainer Container { get; set; }
        public IConfiguration Configuration { get; }


        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();   
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterType<DBContext>().InstancePerRequest();
            AutoMapperModule.ConfigureAutomapperModule(builder);
            ServiceModule.ConfigureServiceModule(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
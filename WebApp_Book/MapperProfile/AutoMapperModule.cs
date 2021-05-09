using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using AutoMapper;
using WebApp_Book.Models;
using Service.Service;
using Service.DB;
using Service;

namespace WebApp_Book.MapperProfile
{
    public class AutoMapperModule : Module
    {

        public static void ConfigureAutomapperModule(ContainerBuilder builder)
        {
            builder.RegisterType<BooksView>().SingleInstance();
            builder.RegisterType<AuthorsView>().SingleInstance();
            builder.RegisterAssemblyTypes(typeof(AutoMapperModule).Assembly).As<AutoMapperProfile>();
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                {
                    cfg.AddProfile(new AutoMapperProfile());
                    cfg.AddProfile(new ServiceProfile());
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
               .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
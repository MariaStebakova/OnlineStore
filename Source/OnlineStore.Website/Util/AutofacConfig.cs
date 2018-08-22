using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using OnlineStore.DataProvider.DataContext;
using OnlineStore.DataProvider.Manager;
using OnlineStore.DataProvider.Repositories;
using OnlineStore.Logic;
using OnlineStore.Model;
using OnlineStore.Website.Controllers;
using OnlineStore.Website.Infrastructure.Abstract;
using OnlineStore.Website.Infrastructure.Concrete;
using OnlineStore.Website.Models;

namespace OnlineStore.Website.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(AccountController).Assembly);

            builder.RegisterType<ApplicationContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register<IAuthenticationManager>(x => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.RegisterType<FormAuthProvider>().As<IAuthProvider>().InstancePerRequest();

            builder.RegisterType<EFServiceRepository>().As<IServiceRepository>().InstancePerRequest();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                                             .AppSettings["Email.WriteAsFile"] ?? "false")
            };
            builder.RegisterType<EmailOrderProcessor>().As<IOrderProcessor>().WithParameter("settings", emailSettings)
                .InstancePerRequest();




            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
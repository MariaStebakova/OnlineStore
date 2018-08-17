using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Ninject.Activation;
using Ninject.Modules;
using Ninject.Web.Common;
using OnlineStore.DataProvider.DataContext;
using OnlineStore.DataProvider.Repositories;
using OnlineStore.Logic;
using OnlineStore.Website.Infrastructure.Abstract;
using OnlineStore.Website.Infrastructure.Concrete;
using OnlineStore.Website.Models;


namespace OnlineStore.Website.Util
{
    public class NinjectRegistrations: NinjectModule
    {
        private static T GetOwinInjection<T>(IContext context) where T : class
        {
            var contextBase = new HttpContextWrapper(HttpContext.Current);
            return contextBase.GetOwinContext().Get<T>();
        }

        public override void Load()
        {
            Bind<IServiceRepository>().To<EFServiceRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                                             .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
            Bind<IAuthProvider>().To<FormAuthProvider>();
            //Bind<ApplicationUserManager>().ToSelf();
            //Bind<ApplicationSignInManager>().ToSelf();
            //Bind<IAuthenticationManager>().ToMethod(x => HttpContext.Current.GetOwinContext().Authentication);
            //Bind<ApplicationUserManager>().ToMethod(GetOwinInjection<ApplicationUserManager>);
            //Bind<ApplicationSignInManager>().ToMethod(GetOwinInjection<ApplicationSignInManager>);
            //Bind<IAuthenticationManager>().ToMethod(context =>
            //{
            //    var contextBase = new HttpContextWrapper(HttpContext.Current);
            //    return contextBase.GetOwinContext().Authentication;
            //});
            Bind<IAuthenticationManager>().ToMethod(c =>
                HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            Bind<ApplicationUserManager>().ToMethod(c =>
                HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()).InRequestScope();
            Bind<ApplicationSignInManager>().ToMethod(c =>
                HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>()).InRequestScope();
        }
        
    }
}
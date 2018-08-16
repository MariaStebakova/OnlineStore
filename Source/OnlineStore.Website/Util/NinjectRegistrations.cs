using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Ninject.Modules;
using OnlineStore.DataProvider.DataContext;
using OnlineStore.DataProvider.Repositories;
using OnlineStore.Logic;
using OnlineStore.Website.Infrastructure.Abstract;
using OnlineStore.Website.Infrastructure.Concrete;


namespace OnlineStore.Website.Util
{
    public class NinjectRegistrations: NinjectModule
    {
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
        }
        
    }
}
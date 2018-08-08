using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using OnlineStore.DataProvider.DataContext;
using OnlineStore.DataProvider.Repositories;


namespace OnlineStore.Website.Util
{
    public class NinjectRegistrations: NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceRepository>().To<EFServiceRepository>();
        }
        
    }
}
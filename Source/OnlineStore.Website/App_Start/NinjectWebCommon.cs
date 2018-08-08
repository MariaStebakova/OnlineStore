using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Web.Mvc;

namespace OnlineStore.Website.App_Start
{
    public class NinjectWebCommon
    {
        private static void RegisterServices(IKernel kernel)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new OnlineStore.Website.Infrastructure.NinjectDependencyResolver(kernel));
        }
    }
} 
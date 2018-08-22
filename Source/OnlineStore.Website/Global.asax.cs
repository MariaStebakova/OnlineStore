using System.Data.Entity;
using OnlineStore.Model;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStore.DataProvider.DataContext;
using OnlineStore.DataProvider.Manager;
using OnlineStore.Website.App_Start;
using OnlineStore.Website.Infrastructure.Binders;
using OnlineStore.Website.Util;

namespace OnlineStore.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Database.SetInitializer(new DbInitializer());
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
        
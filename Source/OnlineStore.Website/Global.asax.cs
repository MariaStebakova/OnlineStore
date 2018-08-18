using System.Data.Entity;
using OnlineStore.Model;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using OnlineStore.DataProvider.DataContext;
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
            // FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
        
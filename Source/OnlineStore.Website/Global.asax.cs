using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using OnlineStore.Model;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using OnlineStore.Website.App_Start;
using OnlineStore.Website.Infrastructure.Binders;
using OnlineStore.Website.Util;

namespace OnlineStore.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));


            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
        
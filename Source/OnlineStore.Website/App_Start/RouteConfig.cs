using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineStore.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Service",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
            );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Service", action = "List", category = (string)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(null,
                "{category}",
                new { controller = "Service", action = "List", page = 1 }
            );

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = "Service", action = "List" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Service", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}

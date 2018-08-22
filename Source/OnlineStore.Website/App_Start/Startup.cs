using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using OnlineStore.Website.Models;
using Owin;

[assembly: OwinStartup(typeof(OnlineStore.Website.Startup))]
namespace OnlineStore.Website
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/UserAccount/Login"),
            });
        }
    }
}
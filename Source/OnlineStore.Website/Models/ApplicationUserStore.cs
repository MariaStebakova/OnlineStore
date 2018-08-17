using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStore.DataProvider.DataContext;
using OnlineStore.Model;

namespace OnlineStore.Website.Models
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationContext db) : base(db)
        {
        }
    }
}
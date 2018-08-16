using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.DataProvider.Repositories;

namespace OnlineStore.Website.Controllers
{
    public class NavController : Controller
    {

        private IServiceRepository repository;

        public NavController(IServiceRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category/* = null*/)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Services
                .Select(service => service.ServiceType)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}
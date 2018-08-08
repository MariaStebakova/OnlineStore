using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.DataProvider.Repositories;
using OnlineStore.Model;
using OnlineStore.Website.Models;

namespace OnlineStore.Website.Controllers
{
    public class ServiceController : Controller
    {
        private IServiceRepository repository;
        private int pageSize = 4;


        public ServiceController(IServiceRepository repo)
        {
            repository = repo;
        }


        public ViewResult List(string category, int page = 1)
        {
            ServicesListViewModel model = new ServicesListViewModel
            {
                Services = repository.Services
                    .Where(p => category == null || p.ServiceType == category)
                    .OrderBy(game => game.ServiceId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    TotalItems = category == null ?
                    repository.Services.Count() :
                    repository.Services.Where(service => service.ServiceType == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}
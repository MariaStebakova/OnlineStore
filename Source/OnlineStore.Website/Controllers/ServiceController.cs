using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineStore.DataProvider.Repositories;
using OnlineStore.Model;
using OnlineStore.Website.Models;

namespace OnlineStore.Website.Controllers
{
    [Authorize(Roles = "user")]
    public class ServiceController : Controller
    {
        private IServiceRepository repository;
        private int pageSize = 8;


        public ServiceController(IServiceRepository repo)
        {
            repository = repo;
        }


        /*public ActionResult List(string category, int page = 1)
        {
            ServicesListViewModel model = new ServicesListViewModel
            {
                Services = repository.Services
                    .Where(p => category == null || p.ServiceType == category)
                    .OrderBy(service => service.ServiceId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                    repository.Services.Count() :
                    repository.Services.Where(service => service.ServiceType == category).Count()
                },
                CurrentCategory = category
            };

            if (model.Services != null && model.Services?.Count() != 0)
                return View(model);

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }*/

        public FileContentResult GetImage(int serviceId)
        {
            Service service = repository.Services.FirstOrDefault(s => s.ServiceId == serviceId);

            if (service != null)
            {
                return File(service.ImageData, service.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult List(string category, int page = 1, string searchString = null)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                ServicesListViewModel model1 = new ServicesListViewModel
                {
                    Services = repository.Services
                        .Where(x => x.Name.Contains(searchString))
                        .OrderBy(service => service.ServiceId)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = repository.Services.Count()
                    },
                    CurrentCategory = null
                };
                return View(model1);

            }
            else
            {
                ServicesListViewModel model2 = new ServicesListViewModel
                {
                    Services = repository.Services
                    .Where(p => category == null || p.ServiceType == category)
                    .OrderBy(service => service.ServiceId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = category == null ?
                        repository.Services.Count() :
                        repository.Services.Where(service => service.ServiceType == category).Count()
                    },
                    CurrentCategory = category
                };
                if (model2.Services != null && model2.Services?.Count() != 0)
                     return View(model2);

                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }

        }
    }
}
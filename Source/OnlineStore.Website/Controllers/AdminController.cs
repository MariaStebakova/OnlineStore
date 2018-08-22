using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq.Language;
using OnlineStore.DataProvider.Repositories;
using OnlineStore.Model;

namespace OnlineStore.Website.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IServiceRepository repository;

        public AdminController(IServiceRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Services);
        }

        public ViewResult Edit(int serviceId)
        {
            Service service = repository.Services.FirstOrDefault((s => s.ServiceId == serviceId));
            return View(service);
        }

        [HttpPost]
        public ActionResult Edit(Service service, HttpPostedFileBase image = null)
        {
            if (image != null)
            {
                service.ImageMimeType = image.ContentType;
                service.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(service.ImageData, 0, image.ContentLength);
            }
            if (ModelState.IsValid)
            {
                repository.SaveService(service);
                TempData["message"] = string.Format("Изменения товара \"{0}\" были сохранены", service.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(service);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Service());
        }

        [HttpPost]
        public ActionResult Delete(int serviceId)
        {
            Service deletedService = repository.DeleteService(serviceId);
            if (deletedService != null)
            {
                TempData["message"] = string.Format("Товар\"{0}\" был удалена", deletedService.Name);
            }

            return RedirectToAction("Index");
        }
    }
}
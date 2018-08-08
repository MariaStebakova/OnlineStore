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
    public class CartController : Controller
    {
        private IServiceRepository repository;
        public CartController(IServiceRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        
        public RedirectToRouteResult AddToCart(Cart cart, int serviceId, string returnUrl)
        {
            Service service = repository.Services
                .FirstOrDefault(s => s.ServiceId == serviceId);

            if (service != null)
            {
                cart.AddItem(service, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int serviceId, string returnUrl)
        {
            Service service = repository.Services
                .FirstOrDefault(s => s.ServiceId == serviceId);

            if (service != null)
            {
                cart.RemoveLine(service);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            return View(new ShippingDetails());
        }

    }
}
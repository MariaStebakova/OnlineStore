using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Website.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View("~/Views/Error/NotFound.cshtml");
        }

        public ActionResult InternalServerError()
        {
            Response.StatusCode = 500;
            return View("~/Views/Error/InternalServerError.cshtml");
        }
    }
}
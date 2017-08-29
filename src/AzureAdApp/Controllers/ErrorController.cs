using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureAdApp.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(string message)
        {
            return View("Error", model: message);
        }
    }
}
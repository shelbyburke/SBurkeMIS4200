using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBurkeMIS4200.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Learn more about Shelby.";

            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Shelby.";

            return View();
        }
    }
}
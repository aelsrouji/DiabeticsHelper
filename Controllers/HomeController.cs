using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiabeticsHelper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Diabetes Helper.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us page.";

            return View();
        }
    }
}
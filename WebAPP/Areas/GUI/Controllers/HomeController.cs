using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPP.Areas.GUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /GUI/Home/
        public ActionResult Home()
        {
            ViewBag.Page = "Home";
            return View();
        }

        public ActionResult PackageTour()
        {
            ViewBag.Page = "PackageTour";
            return View();
        }

        public ActionResult SelectTour()
        {
            ViewBag.Page = "SelectTour";
            return View();
        }

        public ActionResult CustomizedTour()
        {
            ViewBag.Page = "CustomizedTour";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Page = "Contact";
            return View();
        }
    }
}
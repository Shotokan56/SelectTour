using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Areas.GUI.Models;
using WebAPP.Models;

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

        public ActionResult PackageTourEnquiry()
        {
            var model = new SelectTourViewModel()
            {
                ListTourClass = new List<ReferenceValue>()
            };

            model.ListTourClass.Add(new ReferenceValue() { Id = 1, Name = "test", ReferenceId = 1 });
            ViewBag.Page = "PackageTourEnquiry";
            return View(model);
        }

        public ActionResult SelectTour()
        {
            ViewBag.Page = "SelectTour";
            var model = new SelectTourViewModel()
            {
                ListTourClass = new List<ReferenceValue>()
            };

            model.ListTourClass.Add(new ReferenceValue() {Id = 1,Name = "test",ReferenceId = 1});
            return View(model);
        }

        public ActionResult CustomizedTour()
        {
            var model = new SelectTourViewModel()
            {
                ListTourClass = new List<ReferenceValue>()
            };
            ViewBag.Page = "CustomizedTour";
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Page = "Contact";
            return View();
        }
    }
}
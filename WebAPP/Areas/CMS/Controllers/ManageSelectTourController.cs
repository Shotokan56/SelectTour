using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Areas.CMS.Models;

namespace WebAPP.Areas.CMS.Controllers
{
    public class ManageSelectTourController : Controller
    {
        public ActionResult AllSelectTour()
        {
            return View();
        }


        public ActionResult CreateNew()
        {
            return View();
        }

        public ActionResult ListSelectTourPatial()
        {
            //var obj = new SelectTourViewModel()
            //{
            //    SelectTourName = "Best Holidays to Asia with authentic",
            //    SelectTourDestination = "8",
            //    SelectTourDuration = "HN - HCM",
            //    SelectTourPrice = 0
            //};
            //var data = new List<SelectTourViewModel>();
            //data.Add(obj);
            //data.Add(obj);
            //data.Add(obj);

            //return PartialView("ListSelectTourPatial", data);
            return null;
        }

        public ActionResult TrashedSelectTours()
        {
            //var obj = new SelectTourViewModel()
            //{
            //    SelectTourName = "Best Holidays to Asia with authentic",
            //    SelectTourDestination = "8",
            //    SelectTourDuration = "HN - HCM",
            //    SelectTourPrice = 0
            //};
            //var data = new List<SelectTourViewModel>();
            //data.Add(obj);
            //data.Add(obj);
            //data.Add(obj);

            //return View(data);
            return null;
        }

        public ActionResult BookedSelectTours()
        {
            //var obj = new SelectTourViewModel()
            //{
            //    SelectTourName = "Best Holidays to Asia with authentic",
            //    Contact = "125 Quan Thanh",
            //    Email = "Examble@abc.com.vn",
            //};
            //var data = new List<SelectTourViewModel>();
            //data.Add(obj);
            //data.Add(obj);
            //data.Add(obj);
            //return View(data);
            return null;
        }

        public ActionResult DetailBooked()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Areas.CMS.Models;
using WebAPP.Common;

namespace WebAPP.Areas.CMS.Controllers
{
    //[SessionExpire]
    public class ManagePackageTourController : Controller
    {
        public ActionResult AllPackageTour()
        {
            return View();
        }


        public ActionResult Addnewtour()
        {
            return View();  
        }

        public ActionResult ListPackageTourPatial()
        {
            return PartialView("ListPackageTourPatial", TestData());
        }

        public ActionResult TrashedPackageTours()
        {
            return View(TestData());
        }

        public ActionResult AllBookedTours()
        {
            var obj = new PackageTourBookedViewModel()
            {
                Name = "Best Holidays to Asia with authentic",
                DepartureDate = "7",
                TourClass = "HaNoi - Lao",
                ContactName = "Mr.ex"
            };
            var data = new List<PackageTourBookedViewModel>();
            data.Add(obj);
            data.Add(obj);
            data.Add(obj);
            return View(data);
        }

        public ActionResult DetailsBooked()
        {

            return View();
        }

        private List<PackageTourViewModel> TestData()
        {
            var obj = new PackageTourViewModel()
            {
                PackageTourName = "Best Holidays to Asia with authentic",
                PackageTourDestination = "7",
                PackageTourDuration = "HaNoi - Lao",
                PackageTourPrice = 1500
            };
            var data = new List<PackageTourViewModel>();
            data.Add(obj);
            data.Add(obj);
            data.Add(obj);
            return data;
        }
    }
}
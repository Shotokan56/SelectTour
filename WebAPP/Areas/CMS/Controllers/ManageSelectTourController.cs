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
            var obj = new SelectTourViewModel()
            {
                SelectTourName = "Test",
                SelectTourDestination = "Test",
                SelectTourDuration = "Test",
                SelectTourPrice = 0
            };
            var data = new List<SelectTourViewModel>();
            data.Add(obj);
            data.Add(obj);
            data.Add(obj);

            return PartialView("ListSelectTourPatial", data);
        }
    }
}
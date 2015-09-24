﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Areas.CMS.Models;

namespace WebAPP.Areas.CMS.Controllers
{
    public class CustomizedTourController : Controller
    {
        public ActionResult AllCustomizedTours()
        {
            var obj = new CustomizedTourListViewModel()
            {
                ContactName = "kai Muphy",
                Email = "kaimuphy@abc.com",
                ArrivalDate = new DateTime(),
                DepartureDate = new DateTime()
            };
            var data = new List<CustomizedTourListViewModel>();
            data.Add(obj);
            data.Add(obj);
            data.Add(obj);
            return View(data);
        }

        public ActionResult TrashedCustomizedTours()
        {
            var obj = new CustomizedTourListViewModel()
            {
                ContactName = "kai Muphy",
                Email = "kaimuphy@abc.com",
                ArrivalDate = new DateTime(),
                DepartureDate = new DateTime()
            };
            var data = new List<CustomizedTourListViewModel>();
            data.Add(obj);
            data.Add(obj);
            data.Add(obj);
            return View(data);
        }
    }
}
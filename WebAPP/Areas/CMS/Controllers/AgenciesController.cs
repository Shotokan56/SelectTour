using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Areas.CMS.Models;

namespace WebAPP.Areas.CMS.Controllers
{
    public class AgenciesController : Controller
    {
        // GET: CMS/Agency
        public ActionResult AllAgencies()
        {
            var obj = new AgencyListViewModel()
            {
                Name = "kai Muphy",
                Email = "kaimuphy@abc.com",
            };
            var data = new List<AgencyListViewModel>();
            data.Add(obj);
            data.Add(obj);
            data.Add(obj);
            return View(data);
        }

        public ActionResult TrashedAgencies()
        {
            var obj = new AgencyListViewModel()
            {
                Name = "kai Muphy",
                Email = "kaimuphy@abc.com",
            };
            var data = new List<AgencyListViewModel>();
            data.Add(obj);
            data.Add(obj);
            data.Add(obj);
            return View(data);
        }

        public ActionResult AddNew()
        {
            return View();
        }
    }
}
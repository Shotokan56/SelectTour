using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Areas.CMS.Models;

namespace WebAPP.Areas.CMS.Controllers
{
    public class ContactController : Controller
    {
        // GET: CMS/Contact
        public ActionResult AllContact()
        {
            var obj = new Contact()
            {
                FullName = "kai Muphy",
                Title = "Please help me",
            };
            var data = new List<Contact>();
            data.Add(obj);
            data.Add(obj);
            data.Add(obj);
            return View(data);
        }

        public ActionResult TrashedContact()
        {
            var obj = new Contact()
            {
                FullName = "kai Muphy",
                Title = "Please help me",
            };
            var data = new List<Contact>();
            data.Add(obj);
            data.Add(obj);
            data.Add(obj);
            return View(data);
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}
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
        public ActionResult Index()
        {
            return View();
            //return Redirect("CMS/Login");
        }

        public ActionResult Index2()
        {
            return View();
        }
	}
}
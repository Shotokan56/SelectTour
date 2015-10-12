using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Areas.CMS.Models;
using WebAPP.Models;
using SelectTourViewModel = WebAPP.Areas.GUI.Models.SelectTourViewModel;

namespace WebAPP.Areas.GUI.Controllers
{
    public class HomeController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();
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

        public ActionResult GetSlide()
        {
            return PartialView("../Shared/SlideBanner", db.Slides.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Home");
        }

        public ActionResult LoginIndex()
        {
            return PartialView("_Login", new UserViewModel());
        }

        [HttpPost]
        public ActionResult Login(UserViewModel obj)
        {
            ModelState.Clear();
            if (! new WebAPP.Areas.CMS.Controllers.LoginController().Validate(obj))
            {
                return PartialView("_Login", obj);
            }

            var objDbUser = db.Users.FirstOrDefault(o => o.UserName == userVm.UserName);

            if (objDbUser == null)
            {
                ModelState.AddModelError("Message", TextMessage.LoginController_Validate_NotValid);
                return View("Login", userVm);
            }

            //Mapper.CreateMap<User, UserViewModel>();
            //var userViewModel = Mapper.Map<User>(user);

            if (!Hashing.VerifyHashedPassword(objDbUser.PassWord, userVm.PassWord) || string.IsNullOrEmpty(objDbUser.Roles))
            {
                ModelState.AddModelError("Message", TextMessage.LoginController_Validate_NotValid);
                return View("Login", userVm);
            }
            else
            {
                userVm.Roles = objDbUser.Roles;
                Session.Add("User", userVm);
                if (userVm.RememberMe)
                {
                    var cookie = new HttpCookie("AppLogin");
                    cookie.Values.Add("UserName", userVm.UserName);
                    cookie.Expires = DateTime.Now.AddDays(15);
                    Response.Cookies.Add(cookie);
                }
                return RedirectToAction("index", "Home");
            }

            return PartialView("_Login", new UserViewModel());
        }


    }
}
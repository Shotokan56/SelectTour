using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resources;
using WebAPP.Areas.CMS.Models;
using WebAPP.Areas.GUI.Models;
using WebAPP.Common;
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
            var model = new HomeViewModel
            {
                LstPackageTour =
                    db.PackageTours.Where(o => o.Special == true).OrderByDescending(o => o.TourId).Take(3).ToList(),
                LstSelectTour =
                    db.SelectTours.Where(o => o.Special == true).OrderByDescending(o => o.SelectTourId).Take(3).ToList(),
                User = (UserViewModel)Session["User"]
            };
            return View(model);
        }

        public ActionResult PackageTour()
        {
            ViewBag.Page = "PackageTour";
            return View();
        }

       public ActionResult Contact()
        {
            ViewBag.Page = "Contact";
            return View();
        }

        public ActionResult GetSlide()
        {
            return PartialView("../Shared/SlideBanner", db.Slides.Where(o => o.Category == ImageCategory.Slide).ToList());
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(User obj)
        {
            obj.Lock = true;
            obj.PassWord = Hashing.HashPassword(obj.PassWord);
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
            if (!Validate(obj))
            {
                return PartialView("_Login", obj);
            }

            var objDbUser = db.Users.FirstOrDefault(o => o.UserName == obj.UserName
                                                      && o.Roles != Common.SecurityRoles.Admin
                                                      && o.Lock == false);

            if (objDbUser == null)
            {
                ModelState.AddModelError("Message", TextMessage.LoginController_Validate_NotValid);
                return PartialView("_Login", obj);
            }


            if (!Hashing.VerifyHashedPassword(objDbUser.PassWord, obj.PassWord))
            {
                ModelState.AddModelError("Message", TextMessage.LoginController_Validate_NotValid);
                return PartialView("_Login", obj);
            }
            else
            {
                obj.Roles = objDbUser.Roles;
                Session.Add("User", obj);
                return null;
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("User");
            return RedirectToAction("Home");
        }

        private bool Validate(UserViewModel userVm)
        {

            if (string.IsNullOrEmpty(userVm.UserName) || string.IsNullOrWhiteSpace(userVm.UserName))
            {
                ModelState.AddModelError("Message", TextMessage.LoginController_Validate_UserName);
            }

            if (string.IsNullOrEmpty(userVm.PassWord) || string.IsNullOrWhiteSpace(userVm.PassWord))
            {
                ModelState.AddModelError("Message", TextMessage.LoginController_Validate_PassWord);
            }
            return ModelState.IsValid;
        }

        public ActionResult CheckUser()
        {
            if (Session["User"] == null)
            {
                return Json(new { html = "<a href=\"Javascript:ViewLogin()\">Login</a>" });
            }
            else
            {
                var user = (UserViewModel)Session["User"];
                if (Session["User"] != null && user.Roles != Common.SecurityRoles.Admin)
                {
                    return Json(new { html = "<a href =\"/Home/Logout\">Logout " + user.UserName + "</a>" });

                }
                else
                {
                    return Json(new { html = "<a href=\"Javascript:ViewLogin()\">Login</a>" });
                }
            }
        }
    }
}
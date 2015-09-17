using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resources;
using WebAPP.Areas.CMS.Models;
using WebAPP.Common;
using WebAPP.Models;
using AutoMapper;
using System.Web.Security;

namespace WebAPP.Areas.CMS.Controllers
{
    public class LoginController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();
        //
        // GET: /CMS/Login/

        public ActionResult Index(UserViewModel userVm)
        {
            var appLogin = Request.Cookies["AppLogin"];
            userVm.PassWord = "1";
            userVm.RememberMe = true;
            if (appLogin != null)
            {
                userVm.UserName = appLogin.Values["UserName"];
            }
            return View("Login", userVm);
        }

        [HttpPost]
        public ActionResult Verify(UserViewModel userVm)
        {
            ModelState.Clear();
            if (!Validate(userVm))
            {
                return View("Login", userVm);
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
        }

        public ActionResult Logout()
        {
            Session.Remove("User");
            return Index(new UserViewModel());
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
    }
}

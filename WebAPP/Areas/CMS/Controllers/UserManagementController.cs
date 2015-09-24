using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using AutoMapper;
using Resources;
using WebAPP.Common;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Controllers
{
    [SessionExpire]
    public class UserManagementController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();
        
        public ActionResult Index()
        {
            //var lstData = db.Users.ToList();
            return View("ListUser");
        }

        public ActionResult NewUser()
        {
            return View("NewUser");
        }

        public ActionResult NewUserPatial()
        {
            return PartialView("NewUserPatial", new RegisterAccountViewModel());
        }

        //<summary>
        //return ra list
        //</summary>
        //<returns></returns>
        public ActionResult InitListUser()
        {

            //using (WebAPPEntities myContext = new WebAPPEntities())
            //{
            //    System.Data.Objects.ObjectParameter output = new System.Data.Objects.ObjectParameter("CustomerCount", typeof(int));
            //    myContext.GetCustomerCount(output);
            //    Console.WriteLine(output.Value);
            //}
            return PartialView("ListUserPatial", db.Users.OrderBy(o => o.UserId).Skip(0).Take(2).ToList());
        }

        [HttpPost]
        public ActionResult GetDataList(int currentPage, int itemPerPage)
        {
            var data = db.Users.OrderBy(o => o.UserId).Skip(itemPerPage*currentPage - 1).Take(itemPerPage).ToList();
            return PartialView("ListUserPatial", data);
        }

        [HttpPost]
        public ActionResult CreateAndEdit(RegisterAccountViewModel objRegister)
        {
            try
            {
                Validate(objRegister);
                if (ModelState.IsValid)
                {
                    Mapper.CreateMap<RegisterAccountViewModel,User>();
                    var objSave = Mapper.Map<User>(objRegister);
                    objSave.PassWord = Hashing.HashPassword(objSave.PassWord);
                    db.Users.Add(objSave);

                    //Update
                    if(objRegister.UserId > 0)
                        db.Entry(objSave).State = EntityState.Modified;
                    db.SaveChanges();

                    string url = Url.Action("RenderListUser", "UserManagement");
                    return Json(new { success = true, url = url });
                }

                return PartialView("NewUserPatial", objRegister);

            }
            catch (Exception ex)
            {
                objRegister.Message = ex.ToString();
                return PartialView("NewUserPatial", objRegister);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var obj = db.Users.First(o => o.UserId == id);
                Mapper.CreateMap<User,RegisterAccountViewModel>();
                var objReturn = Mapper.Map<RegisterAccountViewModel>(obj);
                objReturn.PassWord = string.Empty;
                return PartialView("NewUserPatial", objReturn);
            }
            catch (Exception ex)
            {
                var objReturn = new RegisterAccountViewModel() {Message = ex.ToString()};
                return PartialView("NewUserPatial", objReturn);
            }
        }

        public ActionResult Delete(int id)
        {
            var objDelete = db.Users.First(o => o.UserId == id);
            db.Users.Remove(objDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
     

        private void Validate(User user)
        {
            ModelState.Clear();
            if (string.IsNullOrEmpty(user.UserName))
                ModelState.AddModelError("UserName",TextMessage.LoginController_Validate_UserName);
            if (string.IsNullOrEmpty(user.PassWord))
                ModelState.AddModelError("PassWord", TextMessage.LoginController_Validate_PassWord);
        }
    }
}
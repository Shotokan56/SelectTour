using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using AutoMapper;
using WebAPP.Areas.CMS.Models;
using WebAPP.Common;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Controllers
{
    public class UserController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();
        public ActionResult AllUser()
        {
            return View(new StatusModel());
        }

        public ActionResult ListUserPatial(int currentPage, int itemPerPage, string search, string status)
        {
            var data = status == "Trashed" ? db.Users.Where(o => o.Remove == true).ToList()
                                       : db.Users.Where(o => o.Remove == null || o.Remove == false).ToList();

            return PartialView(GetListData(data, currentPage, itemPerPage, search));
        }


        private UserListView GetListData(List<User> data, int currentPage, int itemPerPage, string search)
        {
            if (!string.IsNullOrEmpty(search))
                data = db.Users.Where(o => o.UserName.Contains(search)
                 || o.Email.Contains(search)
                 || o.FirstName.Contains(search)
                 || o.FamilyName.Contains(search)
                 || o.CompanyName.Contains(search)
                 || o.PhoneNumber.Contains(search)
                 || o.Address.Contains(search)
                 ).ToList();

            var total = Math.Round((double)(data.Count()) / itemPerPage, 0) + 1;

            var viewModel = new UserListView()
            {
                LstUser = data.OrderByDescending(o => o.User_Id)
                                .Skip((currentPage - 1) * itemPerPage)
                                .Take(itemPerPage).ToList(),
                TotalPage = (int)total
            };
            return viewModel;
        }


        public ActionResult AddAndEditUser()
        {
            var objView = new UserEditView()
            {
                LstRoles = GetRoles()
            };
            return View(objView);
        }

        public ActionResult Save(UserEditView obj)
        {
            try
            {
                Validate(obj);
                if (ModelState.IsValid)
                {
                    var objSave = new User();
                    if (obj.User_Id > 0)
                    {
                        objSave = db.Users.First(o => o.User_Id == obj.User_Id);

                        objSave.User_Id = obj.User_Id;
                        objSave.UserName = obj.UserName;
                        if (!string.IsNullOrEmpty(obj.PassWord))
                            objSave.PassWord = Hashing.HashPassword(obj.PassWord);
                        objSave.Lock = obj.Lock;
                        objSave.Roles = obj.Roles;
                        objSave.Email = obj.Email;
                        objSave.FirstName = obj.FirstName;
                        objSave.FamilyName = obj.FamilyName;
                        objSave.CompanyName = obj.CompanyName;
                        objSave.PhoneNumber = obj.PhoneNumber;
                        objSave.Address = obj.Address;
                    }
                    else
                    {
                        Mapper.CreateMap<UserEditView, User>();
                        objSave = Mapper.Map<User>(obj);
                        objSave.PassWord = Hashing.HashPassword(obj.PassWord);
                    }

                    db.Users.Add(objSave);

                    if (obj.User_Id > 0)
                    {
                        db.Entry(objSave).State = EntityState.Modified;
                    }
                    db.SaveChanges();

                    return RedirectToAction("AllUser");
                }

                obj.LstRoles = GetRoles();

                return View("AddAndEditUser", obj);
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var objUser = db.Users.First(o => o.User_Id == id);
                var objUserViewModel = new UserEditView()
                {
                    User_Id = objUser.User_Id,
                    UserName = objUser.UserName,
                    PassWord = string.Empty,
                    Lock = objUser.Lock,
                    Roles = objUser.Roles,
                    Email = objUser.Email,
                    FirstName = objUser.FirstName,
                    FamilyName = objUser.FamilyName,
                    CompanyName = objUser.CompanyName,
                    PhoneNumber = objUser.PhoneNumber,
                    Address = objUser.Address,
                    Remove = objUser.Remove,
                    LstRoles = GetRoles()
                };
                return View("AddAndEditUser", objUserViewModel);

            }
            catch (Exception ex)
            {

                throw new System.ArgumentException(ex.Message);
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                var objSave = db.Users.First(o => o.User_Id == id);
                objSave.Remove = true;
                db.Users.Add(objSave);
                db.Entry(objSave).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("AllUser");
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }


        public List<SelectListItem> GetRoles()
        {
            var lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Admin", Value = "Admin" });
            lst.Add(new SelectListItem() { Text = "TO", Value = "Agency1" });
            lst.Add(new SelectListItem() { Text = "TA", Value = "Agency2" });
            return lst;
        }

        private void Validate(UserEditView obj)
        {
            ModelState.Clear();
            if (string.IsNullOrEmpty(obj.UserName))
                ModelState.AddModelError("UserName", "UserName is required !");
            if (string.IsNullOrEmpty(obj.Roles))
                ModelState.AddModelError("Roles", "Roles is required !");
            if (string.IsNullOrEmpty(obj.PassWord) && obj.User_Id == 0)
                ModelState.AddModelError("PassWord", "PassWord is required !");
        }


        public ActionResult TrashedUser()
        {
            return View("AllUser", new StatusModel() { Status = "Trashed" });
        }

        public ActionResult Restore(int id)
        {
            try
            {
                var objSave = db.Users.First(o => o.User_Id == id);
                objSave.Remove = false;
                db.Users.Add(objSave);
                db.Entry(objSave).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("TrashedUser");
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WebAPP.Areas.CMS.Models;
using WebAPP.Common;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Controllers
{
    [SessionExpire]
    public class ContactController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();

        public ActionResult TrashedContact()
        {
            return View("AllContact", new StatusModel() { Status = "Trashed" });
        }
        public ActionResult AllContact()
        {
            return View();
        }

        public ActionResult Restore(int id)
        {
            try
            {
                var objSave = db.Contacts.First(o => o.Id == id);
                objSave.Remove = false;
                db.Contacts.Add(objSave);
                db.Entry(objSave).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("TrashedContact");
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }


        

        public ActionResult ListContactPatial(int currentPage, int itemPerPage, string status)
        {
            var data = status == "Trashed" ? db.Contacts.Where(o => o.Remove == true).ToList()
                                       : db.Contacts.Where(o => o.Remove == null || o.Remove == false).ToList();
            var total = Math.Round((double)(data.Count()) / itemPerPage, 0) + 1;

            var viewModel = new ContactListViewModel()
            {
                LstContact = data.OrderByDescending(o => o.Id)
                                .Skip((currentPage - 1) * itemPerPage)
                                .Take(itemPerPage).ToList(),
                TotalPage = (int)total
            };

            return PartialView(viewModel);
        }

      
        public ActionResult Remove(int id)
        {
            var objSave = db.Contacts.First(o => o.Id == id);
            objSave.Remove = true;
            db.Contacts.Add(objSave);
            db.Entry(objSave).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("AllContact");
        }
    }
}

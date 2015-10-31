using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Areas.CMS.Models;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Controllers
{
    public class CustomizedTourController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();
        public ActionResult AllCustomizedTours()
        {
            return View();
        }

        public ActionResult ListCustomizedPatial(int currentPage, int itemPerPage, string status)
        {
            var data = status == "Trashed" ? db.CustomizedTours.Where(o => o.Remove == true).ToList()
                                     : db.CustomizedTours.Where(o => o.Remove == null || o.Remove == false).ToList();

            var total = Math.Round((double)(data.Count()) / itemPerPage, 0) + 1;
            var viewModel = new CustomizedTourListViewModel()
            {
                LstCustomizedTour = data.OrderByDescending(o => o.BookingId)
                               .Skip((currentPage - 1) * itemPerPage)
                               .Take(itemPerPage).ToList(),
                TotalPage = (int)total
            };

            return PartialView("CustomizedPatial", viewModel);
        }

        public ActionResult TrashedCustomizedTours()
        {
            return View("AllCustomizedTours", new StatusModel() { Status = "Trashed" });
        }

        public ActionResult Details(int id)
        {
            var obj = db.CustomizedTours.First(o => o.BookingId == id);
            return View(obj);
        }
        public ActionResult Remove(int id)
        {
            try
            {
                var objSave = db.CustomizedTours.First(o => o.BookingId == id);
                objSave.Remove = true;
                db.CustomizedTours.Add(objSave);
                db.Entry(objSave).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("AllCustomizedTours");
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }

        public ActionResult Restore(int id)
        {
            try
            {
                var objSave = db.CustomizedTours.First(o => o.BookingId == id);
                objSave.Remove = false;
                db.CustomizedTours.Add(objSave);
                db.Entry(objSave).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("TrashedCustomizedTours");
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }
    }
}
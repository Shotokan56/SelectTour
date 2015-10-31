using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebAPP.Areas.CMS.Models;
using WebAPP.Areas.GUI.Models;
using WebAPP.Common;
using WebAPP.Models;
using SelectTourViewModel = WebAPP.Areas.GUI.Models.SelectTourViewModel;

namespace WebAPP.Areas.GUI.Controllers
{
    public class SelectTourController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();
        public ActionResult SelectTour()
        {
            var data = new SelectTourViewModel()
            {
                ListSelectTour = db.SelectTours.Where(o => o.Remove == null || o.Remove == false).ToList(),
                User = (UserViewModel)Session["User"]
            };

            ViewBag.Nationality = db.ReferenceValues.Where(o=>o.ReferenceId == ReferenceId.Nationality).Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            return View(data);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GetTotalTable(string tbString)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var table = serializer.Deserialize<List<TotalRow>>(tbString);

            var returnObj = new TotalTable()
            {
                DataRows = table,
                TotalPrice = table.Sum(i => i.Price)
            };

            return PartialView("TotalTable", returnObj);
        }

        [ValidateInput(false)]
        public ActionResult BookSelectTour(string name, string gender, string email, string nationality, string address, string phone, string selected)
        {
            try
            {
                var objSave = new SelectTourBooked()
                {
                    Address = address,
                    Email = email,
                    Json = selected,
                    Nationality = nationality,
                    Phone = phone,
                    Name = name,
                    Gender = gender
                };

                db.SelectTourBookeds.Add(objSave);
                db.SaveChanges();
                return Json(new {});
            }
            catch (Exception )
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Print(string tourId)
        {
            var ids = tourId.Split(';');
            var lstSelectTour = db.SelectTours.ToList();
            var lstSelect = new List<SelectTour>();
            foreach (var item in ids)
            {
                if (!string.IsNullOrEmpty(item))
                {
                   var add = lstSelectTour.First(o => o.SelectTourId == Int32.Parse(item));
                    if (!lstSelect.Contains(add))
                    {
                        lstSelect.Add(add);
                    }
                }
            }

            return PartialView("Print", lstSelect);
        }
    }
}
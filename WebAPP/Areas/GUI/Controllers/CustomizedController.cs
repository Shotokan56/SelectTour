using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using AutoMapper;
using WebAPP.Areas.GUI.Models;
using WebAPP.Common;
using WebAPP.Models;

namespace WebAPP.Areas.GUI.Controllers
{
    public class CustomizedController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();
        public ActionResult CustomizedTour()
        {
            var viewModel = new CustomizedViewModel()
            {
                ListNationality = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.Nationality).ToList(),
                ListPayment = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.Payment).ToList(),
                ListAccommodation = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.Accommodation).ToList(),
                ListTransportation = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.Transportation).ToList(),
                ListPreferredType = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.PreferredType).ToList(),
                ListMealsIncluded = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.MealsIncluded).ToList(),
                ListWhereDidHear = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.WhereDidHear).ToList()
            };
            ViewBag.Page = "CustomizedTour";
            return View(viewModel);
        }

        public ActionResult BookCustomized(CustomizedTour obj)
        {
            if (CheckValidate(obj))
            {
                db.CustomizedTours.Add(obj);
                db.SaveChanges();
                return RedirectToAction("CustomizedTour");
            }
            else
            {
                Mapper.CreateMap<CustomizedTour, CustomizedViewModel>();
                var result = Mapper.Map<CustomizedViewModel>(obj);
                result.ListNationality = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.Nationality).ToList();
                result.ListPayment = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.Payment).ToList();
                result.ListAccommodation = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.Accommodation).ToList();
                result.ListTransportation = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.Transportation).ToList();
                result.ListPreferredType = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.PreferredType).ToList();
                result.ListMealsIncluded = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.MealsIncluded).ToList();
                result.ListWhereDidHear = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.WhereDidHear).ToList();
                return View("CustomizedTour", result);
            }
        }

        private bool CheckValidate(CustomizedTour obj)
        {
            ModelState.Clear();
            if (string.IsNullOrEmpty(obj.FullName))
                ModelState.AddModelError("FullName", "Full name is required !");
            if (string.IsNullOrEmpty(obj.Email))
                ModelState.AddModelError("Email", "Email is required !");
            if (string.IsNullOrEmpty(obj.Nationality))
                ModelState.AddModelError("Nationality", "Nationality is required !");
            if (string.IsNullOrEmpty(obj.Address))
                ModelState.AddModelError("Address", "Address is required !");
            if (string.IsNullOrEmpty(obj.Phone))
                ModelState.AddModelError("Phone", "Phone is required !");

            return ModelState.IsValid;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebAPP.Common;
using System.Web.Mvc;
using AutoMapper;
using WebAPP.Areas.CMS.Models;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Controllers
{
    //[SessionExpire]
    public class ManagePackageTourController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();
        public ActionResult AllPackageTour()
        {

            return View(new StatusModel());
        }


        public ActionResult Addnewtour()
        {
            var objView = new PackageTourViewModel()
            {
                LstTourStyle = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.TourStyle).ToList()
            };
            return View(objView);
        }


        public ActionResult Edit(int id)
        {
            try
            {
                var objPackageTour = db.PackageTours.First(o => o.TourId == id);
                var objPackageTourViewModel = new PackageTourViewModel()
                {
                    TourId = objPackageTour.TourId,
                    TourName = objPackageTour.TourName,
                    Duration = objPackageTour.Duration,
                    TourRoute = objPackageTour.TourRoute,
                    TourStyle = objPackageTour.TourStyle,
                    ActivityLevel = objPackageTour.ActivityLevel,
                    Date = objPackageTour.Date,
                    SortDescription = objPackageTour.SortDescription,
                    Detail = objPackageTour.Detail,
                    GuestPrice = objPackageTour.GuestPrice,
                    AgencyPrice2 = objPackageTour.AgencyPrice2,
                    AgencyPrice1 = objPackageTour.AgencyPrice1,
                    Special = objPackageTour.Special,
                    Image = objPackageTour.Image,
                    LstTourStyle = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.TourStyle).ToList(),
                };
                return View("Addnewtour", objPackageTourViewModel);

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
                //var objDelete = new PackageTour { TourId = id };
                //db.PackageTours.Attach(objDelete);
                //db.PackageTours.Remove(objDelete);
                //db.SaveChanges();

                var objSave = db.PackageTours.First(o => o.TourId == id);
                objSave.Remove = true;
                db.PackageTours.Add(objSave);
                db.Entry(objSave).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("AllPackageTour");
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }


        [ValidateInput(false)]
        public ActionResult CreateAndEdit(PackageTourViewModel obj)
        {
            try
            {
                Validate(obj);
                if (ModelState.IsValid)
                {
                    Mapper.CreateMap<PackageTourViewModel, PackageTour>();
                    var objSave = Mapper.Map<PackageTour>(obj);
                    db.PackageTours.Add(objSave);

                    if (obj.TourId > 0)
                    {
                        db.Entry(objSave).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                    return RedirectToAction("AllPackageTour");
                }
                obj.LstTourStyle = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.TourStyle).ToList();
                return View("Addnewtour", obj);
            }
            catch (Exception ex)
            {
                obj.Message = ex.ToString();
                return View("Addnewtour", obj);
            }
        }


        private void Validate(PackageTourViewModel obj)
        {
            ModelState.Clear();
            if (string.IsNullOrEmpty(obj.TourName))
                ModelState.AddModelError("TourName", "Tour Name is required !");
        }


        public ActionResult ListPackageTourPatial(int currentPage, int itemPerPage, string search, string status)
        {
            var data = status == "Trashed" ? db.PackageTours.Where(o => o.Remove == true).ToList() 
                                       : db.PackageTours.Where(o => o.Remove == null || o.Remove == false).ToList();

            return PartialView(GetListData(data, currentPage, itemPerPage, search));
        }


        private PackageTourListViewModel GetListData(List<PackageTour> data, int currentPage, int itemPerPage, string search)
        {
            if (!string.IsNullOrEmpty(search))
                data = db.PackageTours.Where(o => (o.Remove == null || o.Remove == false)
                 && (o.TourName.Contains(search)
                 || o.Duration.Contains(search)
                 || o.TourRoute.Contains(search)
                 || o.ActivityLevel.Contains(search)
                 //|| (o.Date != null && o.Date.Value.ToShortDateString().Contains(search))
                 || o.SortDescription.Contains(search)
                 //|| o.Detail.Contains(search)
                 || (o.GuestPrice != null && o.GuestPrice.ToString().Contains(search))
                 || (o.AgencyPrice2 != null && o.AgencyPrice2.ToString().Contains(search))
                 || (o.AgencyPrice1 != null && o.AgencyPrice1.ToString().Contains(search))
                 )).ToList();

            var total = Math.Round((double)(data.Count()) / itemPerPage, 0) + 1;

            var viewModel = new PackageTourListViewModel()
            {
                LstPackageTour = data.OrderByDescending(o => o.Special)
                                .ThenByDescending(o => o.TourId)
                                .Skip((currentPage - 1) * itemPerPage)
                                .Take(itemPerPage).ToList(),
                TotalPage = (int)total
            };
            return viewModel;
        }


        public ActionResult TrashedPackageTours()
        {
            return View("AllPackageTour", new StatusModel() {Status = "Trashed"});
        }


        public ActionResult Restore(int id)
        {
            try
            {
                var objSave = db.PackageTours.First(o => o.TourId == id);
                objSave.Remove = false;
                db.PackageTours.Add(objSave);
                db.Entry(objSave).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("TrashedPackageTours");
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }


        public ActionResult AllBookedTours()
        {
            return View();
        }

        public ActionResult ListBookedPatial(int currentPage, int itemPerPage)
        {
            var data = db.BookingEnquiries.Where(o=>o.Remove == null || o.Remove == false);
            var total = Math.Round((double)(data.Count()) / itemPerPage, 0) + 1;

            var viewModel = new BookedEnquiryViewModel()
            {
                LstBookingEnquiry = data.OrderByDescending(o => o.PackageTourId)
                                .Skip((currentPage - 1) * itemPerPage)
                                .Take(itemPerPage).ToList(),
                TotalPage = (int)total 
            };

            return PartialView(viewModel);
        }

        public ActionResult DetailsBooked(int id)
        {
            var objEnquiry = db.BookingEnquiries.First(o => o.BookId == id);
            var obj = new BookedEnquiryDetailViewModel()
            {
                ObjEnquiry = objEnquiry,
                PackageTour = db.PackageTours.First(o => o.TourId == objEnquiry.PackageTourId)
            };
            return View(obj);
        }

        public ActionResult Remove(int id)
        {
            var objSave = db.BookingEnquiries.First(o => o.BookId == id);
            objSave.Remove = true;
            db.BookingEnquiries.Add(objSave);
            db.Entry(objSave).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("AllBookedTours");
        }
    }
}
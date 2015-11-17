using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AutoMapper;
using WebAPP.Areas.CMS.Models;
using WebAPP.Areas.GUI.Models;
using WebAPP.Common;
using WebAPP.Models;
using SelectTourViewModel = WebAPP.Areas.CMS.Models.SelectTourViewModel;

namespace WebAPP.Areas.CMS.Controllers
{
    public class ManageSelectTourController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();
        public ActionResult AllSelectTour()
        {
            return View(new StatusModel());
        }


        public ActionResult CreateNew()
        {
            var objView = new SelectTourViewModel()
            {
                LstTourStyle = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.TourStyle).ToList(),
                LstAreas = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.Areas).ToList()
            };
            return View(objView);
        }

        public ActionResult ListSelectTourPatial(int currentPage, int itemPerPage, string search, string status)
        {
            var data = status == "Trashed" ? db.SelectTours.Where(o => o.Remove == true).ToList()
                                       : db.SelectTours.Where(o => o.Remove == null || o.Remove == false).ToList();

            return PartialView(GetListData(data, currentPage, itemPerPage, search));
        }

        private SelectTourListViewModel GetListData(List<SelectTour> data, int currentPage, int itemPerPage, string search)
        {
            if (!string.IsNullOrEmpty(search))
                data = db.SelectTours.Where(o => (o.Remove == null || o.Remove == false)
                 && (o.TourName.Contains(search)
                 || o.Duration.Contains(search)
                 || o.TourRoute.Contains(search)
                 )).ToList();

            var total = Math.Round((double)(data.Count()) / itemPerPage, 0) + 1;

            var viewModel = new SelectTourListViewModel()
            {
                LstSelectTour = data.OrderByDescending(o => o.Special)
                                .ThenByDescending(o => o.Sort)
                                .Skip((currentPage - 1) * itemPerPage)
                                .Take(itemPerPage).ToList(),
                TotalPage = (int)total
            };
            return viewModel;
        }

        private void Validate(SelectTourViewModel obj)
        {
            ModelState.Clear();
            if (string.IsNullOrEmpty(obj.TourRoute))
                ModelState.AddModelError("TourName", "Tour Name is required !");
        }


        public ActionResult Edit(int id)
        {
            try
            {
                var objSelectTour = db.SelectTours.First(o => o.SelectTourId == id);
                var objSelectTourViewModel = new SelectTourViewModel()
                {
                    SelectTourId = objSelectTour.SelectTourId,
                    TourName = objSelectTour.TourName,
                    Detail = objSelectTour.Detail,
                    AgencyStandard2 = objSelectTour.AgencyStandard2,
                    AgencyStandard35 = objSelectTour.AgencyStandard35,
                    AgencyStandard69 = objSelectTour.AgencyStandard69,
                    AgencySuperior2 = objSelectTour.AgencySuperior2,
                    AgencySuperior35 = objSelectTour.AgencySuperior35,
                    AgencySuperior69 = objSelectTour.AgencySuperior69,
                    Agency2Standard2 = objSelectTour.Agency2Standard2,
                    Agency2Standard35 = objSelectTour.Agency2Standard35,
                    Agency2Standard69 = objSelectTour.Agency2Standard69,
                    Agency2Superior2 = objSelectTour.Agency2Superior2,
                    Agency2Superior35 = objSelectTour.Agency2Superior35,
                    Agency2Superior69 = objSelectTour.Agency2Superior69,
                    GuestStandard2 = objSelectTour.GuestStandard2,
                    GuestStandard35 = objSelectTour.GuestStandard35,
                    GuestStandard69 = objSelectTour.GuestStandard69,
                    GuestSuperior2 = objSelectTour.GuestSuperior2,
                    GuestSuperior35 = objSelectTour.GuestSuperior35,
                    GuestSuperior69 = objSelectTour.GuestSuperior69,
                    Remove = objSelectTour.Remove,
                    Special = objSelectTour.Special,
                    Style = objSelectTour.Style,
                    Duration = objSelectTour.Duration,
                    TourRoute = objSelectTour.TourRoute,
                    AgencyDeluxe2 = objSelectTour.AgencyDeluxe2,
                    AgencyDeluxe35 = objSelectTour.AgencyDeluxe35,
                    AgencyDeluxe69 = objSelectTour.AgencyDeluxe69,
                    Agency2Deluxe2 = objSelectTour.Agency2Deluxe2,
                    Agency2Deluxe35 = objSelectTour.Agency2Deluxe35,
                    Agency2Deluxe69 = objSelectTour.Agency2Deluxe69,
                    GuestDeluxe2 = objSelectTour.GuestDeluxe2,
                    GuestDeluxe35 = objSelectTour.GuestDeluxe35,
                    GuestDeluxe69 = objSelectTour.GuestDeluxe69,
                    Agency1SingleSupplementStandard = objSelectTour.Agency1SingleSupplementStandard,
                    Agency1SingleSupplementSuperior = objSelectTour.Agency1SingleSupplementSuperior,
                    Agency1SingleSupplementDeluxe = objSelectTour.Agency1SingleSupplementDeluxe,
                    Agency2SingleSupplementStandard = objSelectTour.Agency2SingleSupplementStandard,
                    Agency2SingleSupplementSuperior = objSelectTour.Agency2SingleSupplementSuperior,
                    Agency2SingleSupplementDeluxe = objSelectTour.Agency2SingleSupplementDeluxe,
                    GuestSingleSupplementStandard = objSelectTour.GuestSingleSupplementStandard,
                    GuestSingleSupplementSuperior = objSelectTour.GuestSingleSupplementSuperior,
                    GuestSingleSupplementDeluxe = objSelectTour.GuestSingleSupplementDeluxe,
                    Image = objSelectTour.Image,
                    Areas = objSelectTour.Areas,
                    Sort = objSelectTour.Sort,
                    LstTourStyle = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.TourStyle).ToList(),
                    LstAreas = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.Areas).ToList(),
                };
                return View("CreateNew", objSelectTourViewModel);

            }
            catch (Exception ex)
            {

                throw new System.ArgumentException(ex.Message);
            }
        }



        [ValidateInput(false)]
        public ActionResult CreateAndEdit(SelectTourViewModel obj)
        {
            try
            {
                Validate(obj);
                if (ModelState.IsValid)
                {
                    Mapper.CreateMap<SelectTourViewModel, SelectTour>();
                    var objSave = Mapper.Map<SelectTour>(obj);
                    db.SelectTours.Add(objSave);

                    if (obj.SelectTourId > 0)
                    {
                        db.Entry(objSave).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                    return RedirectToAction("AllSelectTour");
                }
                obj.LstTourStyle = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.TourStyle).ToList();
                return View("CreateNew", obj);
            }
            catch (Exception ex)
            {
                obj.Message = ex.ToString();
                return View("CreateNew", obj);
            }


        }


        public ActionResult Delete(int id)
        {
            try
            {
                var objSave = db.SelectTours.First(o => o.SelectTourId == id);
                objSave.Remove = true;
                db.SelectTours.Add(objSave);
                db.Entry(objSave).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("AllSelectTour");
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }


        public ActionResult TrashedSelectTours()
        {
            return View("AllSelectTour", new StatusModel() { Status = "Trashed" });
        }


        public ActionResult Restore(int id)
        {
            try
            {
                var objSave = db.SelectTours.First(o => o.SelectTourId == id);
                objSave.Remove = false;
                db.SelectTours.Add(objSave);
                db.Entry(objSave).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("TrashedSelectTours");
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }


        public ActionResult BookedSelectTours()
        {
            return View();
        }

        public ActionResult ListBookedPatial(int currentPage, int itemPerPage)
        {
            var data = db.SelectTourBookeds.Where(o => o.Remove == null || o.Remove == false);
            var total = Math.Round((double)(data.Count()) / itemPerPage, 0) + 1;

            var viewModel = new ListBookedSelectViewModel()
            {
                lstData = data.OrderByDescending(o => o.ID)
                                .Skip((currentPage - 1) * itemPerPage)
                                .Take(itemPerPage).ToList(),
                TotalPage = (int)total
            };

            return PartialView(viewModel);
        }

        public ActionResult DetailsBooked(int id)
        {
            var objData = db.SelectTourBookeds.First(o => o.ID == id);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var lstRow = serializer.Deserialize<List<TotalRow>>(objData.Json);

            var table = new TotalTable()
            {
                DataRows = lstRow,
                TotalPrice = lstRow.Sum(i => i.Price)
            };

            var obj = new BookedSelectViewModel()
            {
                objData = objData,
                TotalTable = table
            };
            return View(obj);
        }

        public ActionResult Remove(int id)
        {
            var objSave = db.SelectTourBookeds.First(o => o.ID == id);
            objSave.Remove = true;
            db.SelectTourBookeds.Add(objSave);
            db.Entry(objSave).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("BookedSelectTours");
        }
    }
}
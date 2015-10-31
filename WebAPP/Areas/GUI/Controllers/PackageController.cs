using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using WebAPP.Areas.CMS.Models;
using WebAPP.Areas.GUI.Models;
using WebAPP.Common;
using WebAPP.Models;
using PackageTourViewModel = WebAPP.Areas.GUI.Models.PackageTourViewModel;

namespace WebAPP.Areas.GUI.Controllers
{
    public class PackageController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();
        public ActionResult PackageTour()
        {
            return View();
        }


        public ActionResult ListPackageTourPatialView(int currentPage, int itemPerPage)
        {
            var data = db.PackageTours.Where(o => o.Remove == null || o.Remove == false).ToList();

            var viewModel = new PackageTourViewModel()
            {
                LstPackageTour = data.OrderByDescending(o => o.TourId)
                               .Skip((currentPage - 1) * itemPerPage)
                               .Take(itemPerPage).ToList(),
                User = (UserViewModel)Session["User"],
                TotalPage = (int)Math.Round((double)(data.Count()) / itemPerPage, 0) + 1
            };

            return PartialView(viewModel);
        }

        public ActionResult DetailPackageTour(int id)
        {
            var obj = db.PackageTours.First(o => o.TourId == id);
            Mapper.CreateMap<PackageTour, PackageTourDetailViewModel>();
            var packageTourDetail = Mapper.Map<PackageTourDetailViewModel>(obj);
            packageTourDetail.StyleName = db.ReferenceValues.First(o => o.Id == obj.TourStyle).Name;
            packageTourDetail.User = (UserViewModel) Session["User"];

            return View(packageTourDetail);
        }

        public ActionResult Enquire(int id)
        {
            var obj = new EnquireView()
            {
                PackageTour = db.PackageTours.First(o => o.TourId == id),
                ListClass = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.Class).ToList(),
                ListCountry = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.Nationality).ToList()
            };
            return View(obj);
        }


        public ActionResult SaveEnquire(BookingEnquiry obj)
        {
            var country = "";
            if (!string.IsNullOrEmpty(obj.Country))
                country = db.ReferenceValues.First(o => o.Id == int.Parse(obj.Country)).Name;

            obj.PackageTourName = db.PackageTours.First(o => o.TourId == obj.PackageTourId).TourName;
            obj.TourClassName = db.ReferenceValues.First(o => o.Id == obj.TourClass).Name;
            obj.Country = country;
            db.BookingEnquiries.Add(obj);
            db.SaveChanges();
            return RedirectToAction("DetailPackageTour",new
            {
                id= obj.PackageTourId
            });
        }
    }
}
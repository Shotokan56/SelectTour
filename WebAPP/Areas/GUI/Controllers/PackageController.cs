using System;
using System.Linq;
using System.Web.Mvc;
using WebAPP.Areas.CMS.Models;
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
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Areas.CMS.Models;
using WebAPP.Common;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Controllers
{
    [SessionExpire]
    public class ImageSlideController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();
        public ActionResult ImageSlideIndex()
        {
            var model = new ImageViewModel()
            {
                LstCategory = db.ReferenceValues.Where(o => o.ReferenceId == ReferenceId.ImageCategory).ToList(),
            };
            return View(model);
        }

        public ActionResult GetList()
        {
            var model = new ImageViewModel()
            {
                LstImage = db.Slides.ToList()
            };
            return PartialView("_listImage",model);
        }

        [HttpPost]
        public ActionResult UploadFile(string text, int category)
        {
            var obj = new Slide()
            {
                Text = text
            };
            var file = Request.Files[0];

            if (file != null && file.ContentLength > 0)
            {
                if(category == ImageCategory.Slide)
                obj.Name = "Slide_" + DateTime.Now.ToString("MMddyyyyHHmmssfff")+"."+ file.FileName.Split('.')[1];

                if (category == ImageCategory.Tour)
                    obj.Name = "Tour_" + DateTime.Now.ToString("MMddyyyyHHmmssfff") + "." + file.FileName.Split('.')[1];


                if (!Directory.Exists(Server.MapPath("~/Upload/Slide")))
                    Directory.CreateDirectory(Server.MapPath("~/Upload/Slide"));

                obj.Link = "/Upload/Slide/" + obj.Name;
                file.SaveAs(Server.MapPath("~/Upload/Slide") +"/"+ obj.Name);
                obj.Category = category;
                db.Slides.Add(obj);
                db.SaveChanges();
            }

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var objDelete = db.Slides.FirstOrDefault(o => o.Id == id);
            db.Slides.Remove(objDelete);
            db.SaveChanges();

            if (objDelete != null) System.IO.File.Delete(Server.MapPath("~/Upload/Slide") + "/" + objDelete.Name);
            return RedirectToAction("ImageSlideIndex");
        }
    }
}
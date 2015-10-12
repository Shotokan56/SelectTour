using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Controllers
{
    public class ImageSlideController : Controller
    {
        private WebAPPEntities db = new WebAPPEntities();
        public ActionResult ImageSlideIndex()
        {
            return View();
        }

        public ActionResult GetList()
        {
            return PartialView("_listImage", db.Slides.ToList());
        }

        [HttpPost]
        public ActionResult UploadFile(string text)
        {
            var obj = new Slide()
            {
                Text = text
            };
            var file = Request.Files[0];

            if (file != null && file.ContentLength > 0)
            {
                obj.Name = "Slide_" + DateTime.Now.ToString("MMddyyyyHHmmssfff")+"_"+ file.FileName;

                if (!Directory.Exists(Server.MapPath("~/Upload/Slide")))
                    Directory.CreateDirectory(Server.MapPath("~/Upload/Slide"));

                obj.Link = "/Upload/Slide" + obj.Name;
                file.SaveAs(obj.Link);
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

            if (objDelete != null) System.IO.File.Delete(objDelete.Link);
            return RedirectToAction("ImageSlideIndex");
        }
    }
}
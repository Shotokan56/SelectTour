using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Areas.CMS.Models;
using WebAPP.Models;
using System.IO;
using System.Web.Routing;


namespace WebAPP.Common
{
    public class BaseController : Controller
    {
        public static readonly WebAPPEntities db = new WebAPPEntities();
        public BaseController()
        {

        }

        public List<string> GetRolesForUser(string username)
        {
            using (var objContext = new WebAPPEntities())
            {
                var objUser = objContext.Users.FirstOrDefault(x => x.UserName == username);
                if (objUser == null || string.IsNullOrEmpty(objUser.Roles))
                {
                    return null;
                }
                else
                {
                    var result = objUser.Roles.Split(',').ToList();
                    return result;
                }
            }
        }

        public List<string> GetRolesForUser(UserViewModel objUser)
        {
            if (objUser == null || string.IsNullOrEmpty(objUser.Roles))
            {
                return null;
            }
            else
            {
                var result = objUser.Roles.Split(',').ToList();
                return result;
            }
        }

    }

    public class UI : System.Attribute
    {
        private readonly WebAPPEntities db = new WebAPPEntities();

        public List<Label> GetLabelForPage(int languaeId, int pageId)
        {
            var result = db.Labels.Where(o => o.Language_ID == languaeId && o.Page_ID == pageId).ToList();
            return result;
        }
    }
}
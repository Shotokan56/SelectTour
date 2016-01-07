using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Areas.CMS.Models;
using WebAPP.Models;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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

        public string RewriteTitle(string title)
        {
            title = Regex.Replace(title, "[áàảãạăắằẳẵặâấầẩẫậ]", "a");
            title = Regex.Replace(title, "[óòỏõọôồốổỗộơớờởỡợ]", "o");
            title = Regex.Replace(title, "[éèẻẽẹêếềểễệ]", "e");
            title = Regex.Replace(title, "[íìỉĩị]", "i");
            title = Regex.Replace(title, "[úùủũụưứừửữự]", "u");
            title = Regex.Replace(title, "[ýỳỷỹỵ]", "y");
            title = Regex.Replace(title, "[đ]", "d");

            // replace spaces with single dash
            title = Regex.Replace(title, @"\s+", "-");
            // if we end up with multiple dashes, collapse to single dash            
            title = Regex.Replace(title, @"\-{2,}", "-");
            // make it all lower case
            title = title.ToLower();
            // remove entities
            title = Regex.Replace(title, @"&\w+;", "");
            // remove anything that is not letters, numbers, dash, or space
            title = Regex.Replace(title, @"[^a-z0-9\-\s]", "");
            // replace spaces
            title = title.Replace(' ', '-');
            // collapse dashes
            title = Regex.Replace(title, @"-{2,}", "-");
            // trim excessive dashes at the beginning
            title = title.TrimStart(new[] { '-' });
            // if it's too long, clip it
            if (title.Length > 80)
                title = title.Substring(0, 79);
            // remove trailing dashes
            title = title.TrimEnd(new[] { '-' });

            return title;
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
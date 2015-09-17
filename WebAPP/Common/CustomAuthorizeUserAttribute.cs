using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using WebAPP.Areas.CMS.Models;
using WebAPP.Models;

namespace WebAPP.Common
{
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method)]
    public class CustomAuthorizeUserAttribute : AuthorizeAttribute
    {
        private BaseController basectl = new BaseController();
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //bool isAuthorized = base.AuthorizeCore(httpContext);
            //if (!isAuthorized) return false;
            var roles = Users.Split(',');
            if (HttpContext.Current.Session["User"] != null)
            {
                var userRole = basectl.GetRolesForUser((UserViewModel)HttpContext.Current.Session["User"]);
                if (roles.Any(o => userRole.Any(i => i == o)))
                    return true;
            }
            
            return false;
        }
    }
}
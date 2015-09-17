using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPP.Common
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            // check  sessions here
            if (HttpContext.Current.Session["User"] == null)
            {
                filterContext.Result = new RedirectResult("~/CMS/login/index");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
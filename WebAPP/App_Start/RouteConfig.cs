using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebAPP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // routes.MapRoute(
            //  name: "CMS_Home",
            //  url: "CMS/{controller}/{action}/{id}",
            //  defaults: new { area = "CMS", controller = "Login", action = "Index", id = UrlParameter.Optional },
            //  namespaces: new[] { "WebAPP.Areas.CMS.Controllers" }
            //).DataTokens["area"] = "CMS";


            routes.MapRoute(
                name: "GUI",
                url: "{controller}/{action}/{id}",
                defaults: new { area = "GUI", controller = "Home", action = "Home", id = UrlParameter.Optional },
                namespaces: new[] { "WebAPP.Areas.GUI.Controllers" }
             ).DataTokens["area"] = "GUI";

            //routes.MapRoute(
            //    name: "GUI",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new {controller = "Home", action = "Home", id = UrlParameter.Optional },
            //    namespaces: new[] { "WebAPP.Areas.GUI.Controllers" }
            // ).DataTokens["area"] = "GUI";

            //routes.MapRoute(
            //    name: "test",
            //    url: "PackageTour",
            //    defaults: new { area = "GUI", controller = "PackageTour", action = "PackageTour" }
            // );
        }
    }
}

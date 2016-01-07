using System.Web.Mvc;

namespace WebAPP.Areas.GUI
{
    public class GUIAreaRegistration : AreaRegistration
    {
        public override string AreaName => "GUI";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               "GUI_default",
               "GUI/{controller}/{action}/{id}",
               new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            context.MapRoute(
                 "GUI_Package",
                 "Package-Tour",
                 new { controller = "Package", action = "PackageTour" }
                 );

            context.MapRoute(
               name: "CustomizedTour",
               url: "Customized-Tour",
               defaults: new { controller = "Customized", action = "CustomizedTour", id = UrlParameter.Optional }
            );

            context.MapRoute(
               name: "AboutUs",
               url: "About-Us",
               defaults: new { controller = "Home", action = "AboutUs", id = UrlParameter.Optional }
            );

            context.MapRoute(
              name: "SelectTour",
              url: "Select-Tour",
              defaults: new { controller = "SelectTour", action = "SelectTour", id = "0" }
           );

            context.MapRoute(
            name: "Contact",
            url: "Contact",
            defaults: new { controller = "Home", action = "Contact", id = "0" }
         );

            context.MapRoute(
              name: "TermCondition",
              url: "Terms-Conditions",
              defaults: new { controller = "Home", action = "TermCondition", id = UrlParameter.Optional }
           );

            context.MapRoute(
                name: "DetailPackageTour",
                url: "Package-Tour/{title}/{id}",
                defaults: new { controller = "Package", action = "DetailPackageTour", id = UrlParameter.Optional }
             );

            context.MapRoute(
                name: "DetailSelectTour",
                url: "Select-Tour/{title}/{id}",
                defaults: new { controller = "SelectTour", action = "SelectTour", id = UrlParameter.Optional }
             );

            // context.MapRoute(
            //   name: "Default",
            //   url: "{controller}/{action}/{id}",
            //   defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            //);


            //context.MapRoute(
            //    "GUI_PackageDetail",
            //    "Package_Tour/",
            //    new { controller = "Package", action = "PackageTour", id = UrlParameter.Optional }
            //    );


        }
    }
}
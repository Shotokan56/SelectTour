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
        }
    }
}
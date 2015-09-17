using System.Web.Mvc;

namespace WebAPP.Areas.CMS
{
    public class CMSAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "CMS";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CMS_default",
                "CMS/{controller}/{action}/{id}",
                new { controller = "Login",action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
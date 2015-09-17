using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAPP.Startup))]
namespace WebAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

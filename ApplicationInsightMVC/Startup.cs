using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApplicationInsightMVC.Startup))]
namespace ApplicationInsightMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

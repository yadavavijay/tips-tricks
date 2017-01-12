using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BundlingAndMinificationMVC.Startup))]
namespace BundlingAndMinificationMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

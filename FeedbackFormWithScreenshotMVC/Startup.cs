using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FeedbackFormWithScreenshotMVC.Startup))]
namespace FeedbackFormWithScreenshotMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

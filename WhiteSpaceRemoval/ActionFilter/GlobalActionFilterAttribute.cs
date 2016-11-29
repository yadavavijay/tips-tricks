using System.Web.Mvc;
using System.Configuration;
using WhiteSpaceRemoval.Extension;

namespace WhiteSpaceRemoval
{
    public class GlobalActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var response = filterContext.HttpContext.Response;
            string isDevelopmentMode = ConfigurationManager.AppSettings["developmentmode"];

            if (filterContext.HttpContext.Request.RawUrl != "/sitemap.xml")
            {
                if (isDevelopmentMode != "true")
                {
                    if (response.ContentType == "text/html" && response.Filter != null)
                    {
                        response.Filter = new WhitespaceModule(response.Filter);
                    }
                }
            }
        }
    }
}
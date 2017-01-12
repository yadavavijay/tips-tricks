using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace BundlingAndMinificationMVC.Controllers
{
    //[Authorize] //only authorized users can generate bundle
    public class GenerateBundleController : Controller
    {
        public string Execute()
        {
            string urlPrefix = Request.Url.GetLeftPart(UriPartial.Authority);

            var bundlePaths = new List<KeyValuePair<string, string>>();

            bundlePaths.Add(new KeyValuePair<string, string>("/bundles/jquery", "jquery.js"));
            bundlePaths.Add(new KeyValuePair<string, string>("/bundles/jqueryval", "jqueryval.js"));
            bundlePaths.Add(new KeyValuePair<string, string>("/bundles/modernizr", "modernizr.js"));
            bundlePaths.Add(new KeyValuePair<string, string>("/bundles/bootstrap", "bootstrap.js"));
            bundlePaths.Add(new KeyValuePair<string, string>("/content/css", "site.css"));

            foreach (var item in bundlePaths)
            {
                string downloadFileAt = Server.MapPath("~/") + "scripts/dynamicbundles/" + item.Value;
                WebClient myWebClient = new WebClient();
                myWebClient.DownloadFile(new Uri(urlPrefix + item.Key), downloadFileAt);
            }

            return "Bungle generated at /scripts/dynamicbundles/, now upload them on production cdn.";
        }
    }
}
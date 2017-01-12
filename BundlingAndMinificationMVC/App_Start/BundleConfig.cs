using System.Configuration;
using System.Web.Optimization;

namespace BundlingAndMinificationMVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // use in-memory bundle
            string usebundle = ConfigurationManager.AppSettings["usedundle"];
            if (usebundle == "true")
            {
                BundleTable.EnableOptimizations = true;  // OR <compilation debug="false" targetFramework="4.5" /> on production
            }


            // use cdn bundle files
            string usedundlecdn = ConfigurationManager.AppSettings["usedundlecdn"];
            if (usedundlecdn == "true")
            {
                bundles.UseCdn = true;
            }


            // cdn bundle details and version control
            string cachecdnbundleversion = ConfigurationManager.AppSettings["cachecdnbundleversion"];
            var version = System.Reflection.Assembly.GetAssembly(typeof(Controllers.HomeController)).GetName().Version.ToString();
            var cdnUrl = "http://cdn-yourwebsite.com/knorish-static-assets/bundles/{0}?" + version + "-" + cachecdnbundleversion;


            // bundling
            bundles.Add(new ScriptBundle("~/bundles/jquery", string.Format(cdnUrl, "jquery.js")).Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval", string.Format(cdnUrl, "jqueryval.js")).Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr", string.Format(cdnUrl, "modernizr.js")).Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap", string.Format(cdnUrl, "bootstrap.js")).Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/content/css", string.Format(cdnUrl, "site.css")).Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            // Further steps: Generate bundle files offline (not in-memory) from http://localhost:41667/generatebundle/execute and upload on CDN storage












            // Default code
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}

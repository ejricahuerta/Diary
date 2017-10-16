using System.Web;
using System.Web.Optimization;

namespace Diary
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery.min.js", "~/js/jquery.fancybox.pack.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/js/modernizr*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/js/bootstrap.min.js", "~/js/retina.min.js", "~/js/main.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css", "~/Content/*.css", 
                      "~/Content/animate.min.css",
                      "~/Content/main.css", "~/Content/responsive.css",
                      "~/Content/flexsider.css",
                      "~/Content/font-icon.css", "~/Content/jquery.fancobox.css"
                      ));
        }
    }
}

using System.Web;
using System.Web.Optimization;

namespace Diary_2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/css").Include(
                        "~/css/*.css", "~/css/effects/*.css"));
            bundles.Add(new ScriptBundle("~/bundles/css-effects").Include(
            "~/css/effects/*.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
            "~/js/*.js", "~/js/effects/*.js"));

        }
    }
}

using System.Web;
using System.Web.Optimization;

namespace BookinSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.4.js",
                        "~/Scripts/jquery-ui-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap/bootstrap-notify.js"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //            "~/Scripts/bootstrap/bootstrap.js",
            //            "~/Scripts/bootstrap/bootstrap-notify.js"
            //        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-responsive.min.css"));

            //bundles.Add(new StyleBundle("~/bundles/css").Include(
            //          "~/Scripts/bootstrap.min.css",
            //          "~/Scripts/bootstrap-responsive.min.css",
            //          "~/Content/site.css",
            //          "~/Content/bootstrap.min.css",
            //          "~/Content/bootstrap-responsive.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                      "~/Scripts/jquery.validate*"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;

            bundles.IgnoreList.Clear();
 
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));
 
            //bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
            //            "~/Scripts/bootstrap.min.js"));
 
            //bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
            //            "~/Content/bootstrap.css",
            //            "~/Content/bootstrap.min.css",
            //            "~/Content/bootstrap-responsive.min.css"));
        }
    }
}

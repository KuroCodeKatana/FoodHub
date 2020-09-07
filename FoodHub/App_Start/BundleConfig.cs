using System.Web;
using System.Web.Optimization;

namespace FoodHub
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/assets/css/font-awesome.min.css",
                      "~/Content/assets/fonts/iconmoon.css",
                      "~/Content/assets/css/main.css",
                      "~/Content/assets/extras/animate.css",
                      "~/Content/assets/extras/owl.carousel.css",
                      "~/Content/assets/extras/owl.theme.css",
                      "~/Content/assets/extras/pikaday.css",
                      "~/Content/assets/css/responsive.css",
                      "~/Content/assets/css/slicknav.css"
                      ));
        }
    }
}

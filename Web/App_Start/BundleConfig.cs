using System.Web;
using System.Web.Optimization;

namespace eVisaWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/assets").Include(
                //JS Global Compulsory
                "~/Scripts/assets/plugins/jquery/jquery.js",
                "~/Scripts/assets/plugins/jquery/jquery.min.js",
                "~/Scripts/assets/plugins/jquery/jquery-migrate.js",
                "~/Scripts/assets/plugins/jquery/jquery-migrate.min.js",
                "~/Scripts/assets/plugins/bootstrap/js/bootstrap.js",
                "~/Scripts/assets/plugins/bootstrap/js/bootstrap.min.js",

                //JS Implementing Plugins
                "~/Scripts/assets/plugins/back-to-top.js",
                "~/Scripts/assets/plugins/smoothScroll.js",

                //JS Customization
                "~/Scripts/assets/js/custom.js",

                //JS Page Level
                "~/Scripts/assets/js/app.js"

                ));

            bundles.Add(new StyleBundle("~/Scripts/assets/css").Include(
                //CSS Global Compulsory
                      "~/Scripts/assets/plugins/bootstrap/css/bootstrap.min.css",
                      "~/Scripts/assets/css/style.css",

                //CSS Header and Footer
                      "~/Scripts/assets/css/headers/header-default.css",
                      "~/Scripts/assets/css/footers/footer-v1.css",

                //CSS Implementing Plugins
                      "~/Scripts/assets/plugins/animate.css",
                      "~/Scripts/assets/plugins/line-icons/line-icons.css",
                      "~/Scripts/assets/plugins/font-awesome/css/font-awesome.css",

                //CSS Theme
                      "~/Scripts/assets/css/theme-colors/default.css",

                //CSS Customization
                      "~/Scripts/assets/css/custom.css"

                      ));
        }
    }
}

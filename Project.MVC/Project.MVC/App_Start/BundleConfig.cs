using System.Web.Optimization;

namespace Project.MVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // ------------------------- StoreContent ------------------------- //
            bundles.Add(new StyleBundle("~/StoreContent/bootstrap/css").Include(
                      "~/Content/StoreContent/bootstrap/css/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/StoreContent/bootstrap/script").Include(
                      "~/Content/StoreContent/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/StoreContent/style/css").Include(
                      "~/Content/StoreContent/css/style.css"));

            //bundles.Add(new StyleBundle("~/StoreContent/fontawesome/css").Include(
            //          "~/Content/StoreContent/fonts/style.css"));

            bundles.Add(new ScriptBundle("~/StoreContent/footable/script").Include(
                      "~/Content/StoreContent/js/footable.js",
                      "~/Content/StoreContent/js/footable.sortable.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/bootstrap-touchspin/script").Include(
                      "~/Content/StoreContent/js/bootstrap.touchspin.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/grids/script").Include(
                      "~/Content/StoreContent/js/grids.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/hide-max-list/script").Include(
                      "~/Content/StoreContent/js/hideMaxListItem-min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/home/script").Include(
                      "~/Content/StoreContent/js/home.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquert-cycle2/script").Include(
                      "~/Content/StoreContent/js/jquery.cycle2.min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-custom-scroll/script").Include(
                      "~/Content/StoreContent/js/jquery.mCustomScrollbar.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-parallax/script").Include(
                      "~/Content/StoreContent/js/jquery.parallax-1.1.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-scrollme/script").Include(
                      "~/Content/StoreContent/js/jquery.scrollme.min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-validate/script").Include(
                      "~/Content/StoreContent/js/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-zoom/script").Include(
                      "~/Content/StoreContent/js/jquery.zoom.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/owl-carousel/script").Include(
                      "~/Content/StoreContent/js/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/owl-carousel/script").Include(
                      "~/Content/StoreContent/js/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/pace/script").Include(
                      "~/Content/StoreContent/js/pace.min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/script/script").Include(
                      "~/Content/StoreContent/js/script.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/sidebar-nav/script").Include(
                      "~/Content/StoreContent/js/sidebar-nav.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/skrollr/script").Include(
                      "~/Content/StoreContent/js/skrollr.min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/smoothproducts-thumb/script").Include(
                      "~/Content/StoreContent/js/smoothproducts-thumb.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/smoothproducts/script").Include(
                      "~/Content/StoreContent/js/smoothproducts.min.js"));
        }
    }
}

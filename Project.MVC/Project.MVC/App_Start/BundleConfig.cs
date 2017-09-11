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

            bundles.Add(new ScriptBundle("~/bundles/unobstrusive").Include(
                       "~/Scripts/jquery.js",
                       "~/Scripts/jquery.unobtrusive*"));

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

            bundles.Add(new StyleBundle("~/StoreContent/skin-1/css").Include(
                      "~/Content/StoreContent/css/skin-1.css"));

            bundles.Add(new StyleBundle("~/StoreContent/home-v7/css").Include(
                      "~/Content/StoreContent/css/home-v7.css"));

            bundles.Add(new StyleBundle("~/StoreContent/cart-nav/css").Include(
                      "~/Content/StoreContent/css/cart-nav.css"));

            bundles.Add(new ScriptBundle("~/StoreContent/pace/script").Include(
                      "~/Content/StoreContent/js/pace.min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/bootstrap-touchspin/script").Include(
                      "~/Content/StoreContent/js/bootstrap.touchspin.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/grids/script").Include(
                      "~/Content/StoreContent/js/grids.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/hide-max-list/script").Include(
                      "~/Content/StoreContent/js/hideMaxListItem-min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/home/script").Include(
                      "~/Content/StoreContent/js/home.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-cycle2/script").Include(
                      "~/Content/StoreContent/js/jquery.cycle2.min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-easing/script").Include(
                      "~/Content/StoreContent/js/jquery.easing.1.3.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-custom-scroll/script").Include(
                      "~/Content/StoreContent/js/jquery.mCustomScrollbar.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-custom-scroll/script").Include(
                      "~/Content/StoreContent/js/jquery.mCustomScrollbar.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-parallax/script").Include(
                      "~/Content/StoreContent/js/jquery.parallax-1.1.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-mousewheel/script").Include(
                      "~/Content/StoreContent/js/jquery.mousewheel.min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-scrollme/script").Include(
                      "~/Content/StoreContent/js/jquery.scrollme.min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-validate/script").Include(
                      "~/Content/StoreContent/js/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-zoom/script").Include(
                      "~/Content/StoreContent/js/jquery.zoom.js"));

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

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-fitvids/script").Include(
                      "~/Content/StoreContent/plugins/bxslider/plugins/jquery.fitvids.js"));

            bundles.Add(new StyleBundle("~/StoreContent/jquery-bxslider/css").Include(
                      "~/Content/StoreContent/plugins/bxslider/jquery.bxslider.css"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-bxslider/script").Include(
                      "~/Content/StoreContent/plugins/bxslider/jquery.bxslider.min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/icheck/script").Include(
                      "~/Content/StoreContent/plugins/icheck-1.x/icheck.min.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/intense/script").Include(
                      "~/Content/StoreContent/js/plugins/intense-images-master/intense.js"));

            bundles.Add(new ScriptBundle("~/StoreContent/jquery-magnific/script").Include(
                      "~/Content/StoreContent/plugins/magnific/jquery.magnific-popup.min.js"));

            bundles.Add(new StyleBundle("~/StoreContent/magnific/css").Include(
                      "~/Content/StoreContent/plugins/magnific/magnific-popup.css"));

            bundles.Add(new ScriptBundle("~/StoreContent/bootstrap-rating/script").Include(
                      "~/Content/StoreContent/plugins/rating/bootstrap-rating.min.js"));

            bundles.Add(new StyleBundle("~/StoreContent/bootstrap-rating/css").Include(
                      "~/Content/StoreContent/plugins/rating/bootstrap-rating.css"));

            bundles.Add(new ScriptBundle("~/StoreContent/swiper/script").Include(
                      "~/Content/StoreContent/plugins/swiper-master/js/swiper.jquery.min.js"));

            bundles.Add(new StyleBundle("~/StoreContent/swiper/css").Include(
                      "~/Content/StoreContent/plugins/swiper-master/css/swiper-min.css"));

            bundles.Add(new ScriptBundle("~/StoreContent/file-input/script").Include(
                      "~/Content/StoreContent/plugins/fileinput/sortable.min.js",
                      "~/Content/StoreContent/plugins/fileinput/fileinput.min.js",
                      "~/Content/StoreContent/plugins/fileinput/pt-BR.js"));

            bundles.Add(new StyleBundle("~/StoreContent/file-input/css").Include(
                      "~/Content/StoreContent/css/fileinput.min.css"));

            bundles.Add(new StyleBundle("~/StoreContent/product-details/css").Include(
                      "~/Content/StoreContent/css/product-details-5.css"));

            bundles.Add(new ScriptBundle("~/StoreContent/necessary/script").Include(
                      "~/Content/StoreContent/jquery.min.js",
                      "~/Content/StoreContent/bootstrap.min.js"));

            //PanelContent

            bundles.Add(new StyleBundle("~/PanelContent/bootstrap/css").Include(
                      "~/Content/PanelContent/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/PanelContent/fontawesome/css").Include(
                      "~/Content/PanelContent/font-awesome/4.5.0/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/PanelContent/googleapis/css").Include(
                      "~/Content/PanelContent/css/fonts.googleapis.com.css"));

            bundles.Add(new StyleBundle("~/PanelContent/ace-min/css").Include(
                      "~/Content/PanelContent/css/ace.min.css"));

            bundles.Add(new StyleBundle("~/PanelContent/ace-part2/css").Include(
                      "~/Content/PanelContent/css/ace-part2.min.css"));

            bundles.Add(new StyleBundle("~/PanelContent/ace-skins/css").Include(
                      "~/Content/PanelContent/css/ace-skins.min.css"));

            bundles.Add(new StyleBundle("~/PanelContent/ace-rtl/css").Include(
                      "~/Content/PanelContent/css/ace-rtl.min.css"));

            bundles.Add(new StyleBundle("~/PanelContent/ace-ie/css").Include(
                      "~/Content/PanelContent/css/ace-ie.min.css"));

            bundles.Add(new ScriptBundle("~/PanelContent/ace-extra/script").Include(
                      "~/Content/PanelContent/js/ace-extra.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/html5shiv/script").Include(
                      "~/Content/PanelContent/js/html5shiv.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/respond/script").Include(
                      "~/Content/PanelContent/js/respond.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/jquery-214/script").Include(
                      "~/Content/PanelContent/js/jquery-2.1.4.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/jquery-1113/script").Include(
                      "~/Content/PanelContent/js/jquery-1.11.3.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/bootstrap/script").Include(
                      "~/Content/PanelContent/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/excanvas/script").Include(
                      "~/Content/PanelContent/js/excanvas.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/jquery-ui-custom/script").Include(
                      "~/Content/PanelContent/js/jquery-ui.custom.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/jquery-ui-touch-punch/script").Include(
                      "~/Content/PanelContent/js/jquery.ui.touch-punch.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/jquery-easypiechart/script").Include(
                      "~/Content/PanelContent/js/jquery.easypiechart.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/jquery-sparkline/script").Include(
                      "~/Content/PanelContent/js/jquery.sparkline.index.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/jquery-float/script").Include(
                      "~/Content/PanelContent/js/jquery.flot.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/jquery-float-pie/script").Include(
                      "~/Content/PanelContent/js/jquery.flot.pie.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/jquery-float-resize/script").Include(
                      "~/Content/PanelContent/js/jquery.flot.resize.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/ace-elements/script").Include(
                      "~/Content/PanelContent/js/ace-elements.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/ace/script").Include(
                      "~/Content/PanelContent/js/ace.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/jquery-datatables/script").Include(
                      "~/Content/PanelContent/js/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/jquery-datatables-bootstrap/script").Include(
                      "~/Content/PanelContent/js/jquery.dataTables.bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/datatables-buttons/script").Include(
                      "~/Content/PanelContent/js/dataTables.buttons.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/buttons-flash/script").Include(
                      "~/Content/PanelContent/js/buttons.flash.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/buttons-html5/script").Include(
                      "~/Content/PanelContent/js/buttons.html5.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/buttons-print/script").Include(
                      "~/Content/PanelContent/js/buttons.print.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/buttons-colvis/script").Include(
                      "~/Content/PanelContent/js/buttons.colVis.min.js"));

            bundles.Add(new ScriptBundle("~/PanelContent/datatables-select/script").Include(
                      "~/Content/PanelContent/js/dataTables.select.min.js"));
      
        }
    }
}

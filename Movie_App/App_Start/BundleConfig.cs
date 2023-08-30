﻿using System.Web;
using System.Web.Optimization;

namespace Movie_App
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
            bundles.Add(new ScriptBundle("~/bundles/jqueryDataTables").Include(
                     "~/Scripts/js2/jquery.dataTables.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/dataTablesBootstrap").Include(
                       "~/Scripts/js2/dataTables.bootstrap4.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/Feather").Include(
                     "~/Scripts/js2/feather.min.js"));
             bundles.Add(new ScriptBundle("~/bundles/script").Include(
                     "~/Scripts/js2/script.js"));
            bundles.Add(new ScriptBundle("~/bundles/FontAwesome").Include(
                     "~/Scripts/js2/Fontawesome.js"));


          /*  bundles.Add(new ScriptBundle("~/bundles/bootstrap5").Include(
                     "~/Scripts/js/bootstrap.min.js"));*/

            bundles.Add(new ScriptBundle("~/bundles/bstrap").Include(
                      "~/Scripts/bootstrap.bundle.min.js"));


         

            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                "~/Scripts/js/Index.js"));

            bundles.Add(new StyleBundle("~/Content/Movie").Include(
                     "~/Content/css/bootstrap.min.css.map",
                     "~/Content/css/global.css",
                     "~/Content/css/index.css",
                     "~/Content/css/bootstrap.min.css",
                      "~/Content/css/Admin.css",
                     "~/Content/css/font-awesome.min.css"


               ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/googleapis.css",
                      "~/Content/css/style.css",
                      "~/Content/css/fontawesome/css/fontawesome.min.css",
                      "~/Content/css/fontawesome/css/fontawesome.all.min.css"



                      ));
           


        }
    }
}

            /*  bundles.Add(new ScriptBundle("~/bundles/header").Include(
                 "~/Scripts/js/header.js"
                 ));
              bundles.Add(new ScriptBundle("~/bundles/main").Include(
                  "~/Scripts/js/main.js"
                  ));
              bundles.Add(new ScriptBundle("~/bundles/detail").Include(
                "~/Scripts/js/details.js"
                ));


              bundles.Add(new ScriptBundle("~/bundles/jqueryDataTables").Include(
                       "~/Scripts/js2/jquery.dataTables.min.js"));
  *//*
              bundles.Add(new ScriptBundle("~/bundles/dataTablesBootstrap").Include(
                        "~/Scripts/js2/dataTables.bootstrap4.min.js"));

              bundles.Add(new ScriptBundle("~/bundles/bootstrap5").Include(
                        "~/Scripts/bootstrap.min.js"));*/
            /*bundles.Add(new ScriptBundle("~/bundles/Feather").Include(
                     "~/Scripts/js2/feather.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/slimscroll").Include(
                     "~/Scripts/js2/jquery.slimscroll.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/apexchart").Include(
                      "~/Scripts/js2/apexchart/apexcharts.min.js",
                      "~/Scripts/js2/apexchart/chart-data.js"));
            bundles.Add(new ScriptBundle("~/bundles/owl").Include(
                "~/Scripts/js2/owlcarousel/owl.carousel.min.js"));*/
           /* bundles.Add(new ScriptBundle("~/bundles/FontAwesome").Include(
                     "~/Scripts/js2/Fontawesome.js"));*/
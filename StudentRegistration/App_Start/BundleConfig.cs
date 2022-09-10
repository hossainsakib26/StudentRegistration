﻿using System.Web;
using System.Web.Optimization;

namespace StudentRegistration
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new Bundle("~/bundles/unobtrusive-ajax").Include("~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/javaScript").Include("~/Scripts/My_JS/academicClass.js"));

            //acadClass
            bundles.Add(new Bundle("~/bundles/rout-changer").Include("~/Scripts/My_JS/route-changer.js"));
            bundles.Add(new Bundle("~/bundles/acad-class-js").Include("~/Scripts/My_JS/acad-class.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap.min.css",
                "~/Content/site.css",
                "~/Content/MyContent/MyCSS.css"));

        }
    }
}

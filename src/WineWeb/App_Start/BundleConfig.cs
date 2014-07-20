﻿using System.Web;
using System.Web.Optimization;

namespace WineWeb
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ckeditorAndckefinder").Include(
                      "~/ckeditor/ckeditor.js",
                      "~/ckfinder/ckfinder_v1.js"));



            bundles.Add(new ScriptBundle("~/bundles/jjmcddition").Include(
                //"~/scripts/jquery-migrate-1.2.1.min.js",
                // "~/scripts/jquery.jcarousel.min.js",
                    "~/scripts/flowplayer-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jjmc").Include(

                 "~/scripts/TweenMax.js",
                 "~/scripts/common.js"
               ));


            // 使用 Modernizr 的开发版本进行开发和了解信息。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/Admin").Include("~/Content/LiuAdmin.css", "~/Content/LiuAdmin.css"));
            bundles.Add(new StyleBundle("~/Content/ckeditorAndckefinder").Include("~/ckeditor/skins/moono/editor.css",
                "~/ckeditor/skins/moono/dialog.css"));

        }
    }
}
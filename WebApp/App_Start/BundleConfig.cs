﻿using System.Web;
using System.Web.Optimization;

namespace WebApp
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-3.4.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout/widgets").Include(
                        "~/Scripts/GithubViewModels/widgets/search-widget.js",
                        "~/Scripts/GithubViewModels/widgets/user-widget.js",
                        "~/Scripts/GithubViewModels/widgets/repos-widget.js",
                        "~/Scripts/GithubViewModels/widgets/stargazers-widget.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/knockout/viewmodels").Include(
                        "~/Scripts/GithubViewModels/GithubUserViewModel.js"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}

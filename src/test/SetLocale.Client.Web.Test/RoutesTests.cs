﻿using System.Web.Mvc;
using System.Web.Routing;

using MvcContrib.TestHelper;
using NUnit.Framework;

using SetLocale.Client.Web.Configurations;
using SetLocale.Client.Web.Controllers;
using SetLocale.Client.Web.Helpers;

namespace SetLocale.Client.Web.Test
{
    [TestFixture]
    public class RoutesTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        [Test]
        public void HomeControllerRoutes()
        {
            "~/".WithMethod(HttpVerbs.Get).ShouldMapTo<HomeController>(action => action.Index());
            "~/home".WithMethod(HttpVerbs.Get).ShouldMapTo<HomeController>(action => action.Index());
            "~/home/index".WithMethod(HttpVerbs.Get).ShouldMapTo<HomeController>(action => action.Index());
        }

        [Test]
        public void TagControllerRoutes()
        {
            "~/tag/index/deneme".WithMethod(HttpVerbs.Get).ShouldMapTo<TagController>(action => action.Index("deneme"));
        }

        [Test]
        public void AdminControllerRoutes()
        {
            "~/admin/newtranslator".ShouldMapTo<AdminController>(action => action.NewTranslator());
            "~/admin/index".ShouldMapTo<AdminController>(action => action.Index());
            "~/admin/users".ShouldMapTo<AdminController>(action => action.Users());
            "~/admin/apps".ShouldMapTo<AdminController>(action => action.Apps());
        }

        [Test]
        public void KeyControllerRoutes()
        {
            "~/key/all".WithMethod(HttpVerbs.Get).ShouldMapTo<KeyController>(action => action.All());
            "~/key/my".WithMethod(HttpVerbs.Get).ShouldMapTo<KeyController>(action => action.My());
            "~/key/nottranslated".WithMethod(HttpVerbs.Get).ShouldMapTo<KeyController>(action => action.NotTranslated());

            "~/key/new".WithMethod(HttpVerbs.Get).ShouldMapTo<KeyController>(action => action.New());
           

            var keyEditRoute = "~/key/edit/sign_up".WithMethod(HttpVerbs.Get);
            keyEditRoute.Values["lang"] = ConstHelper.tr;
            keyEditRoute.ShouldMapTo<KeyController>(action => action.Edit("sign_up", ConstHelper.tr));

            "~/key/detail/sign_up".WithMethod(HttpVerbs.Get).ShouldMapTo<KeyController>(action => action.Detail());
        }

        [Test]
        public void AppControllerRoutes()
        {
            "~/app/new".WithMethod(HttpVerbs.Get).ShouldMapTo<AppController>(action => action.New());
            "~/app/index".WithMethod(HttpVerbs.Get).ShouldMapTo<AppController>(action => action.Index());
        }

        [Test]
        public void UserControllerRoutes()
        {
            "~/user/index".WithMethod(HttpVerbs.Get).ShouldMapTo<UserController>(action => action.Index());
            "~/user/apps".WithMethod(HttpVerbs.Get).ShouldMapTo<UserController>(action => action.Apps());
            "~/user/new".WithMethod(HttpVerbs.Get).ShouldMapTo<UserController>(action => action.New());
            "~/user/reset".WithMethod(HttpVerbs.Get).ShouldMapTo<UserController>(action => action.Reset());
            "~/user/login".WithMethod(HttpVerbs.Get).ShouldMapTo<UserController>(action => action.Login());
            "~/user/logout".WithMethod(HttpVerbs.Get).ShouldMapTo<UserController>(action => action.Logout());
        }


        [Test]
        public void LangControllerRoutes()
        {
            var langChangeRoute = "~/lang/change".WithMethod(HttpVerbs.Get);
            langChangeRoute.Values["id"] = "1";
            langChangeRoute.ShouldMapTo<LangController>(action => action.Change("1"));
        }



    }
}


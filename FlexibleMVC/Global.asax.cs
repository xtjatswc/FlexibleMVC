/*
 * 用户： zxs
 * 日期: 2018/5/18
 * 时间: 10:13
 */
using FlexibleMVC.Base;
using FlexibleMVC.Web.RouteConstraint;
using FluentData;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;

namespace FlexibleMVC.Web
{

    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Admin_Default",
                url: "Admin_{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                namespaces: new string[] { "FlexibleMVC.Web.Admin.Controllers" },
                constraints: new { controller = new AdminRouteConstraint() }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{*c}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                namespaces: new string[] { "FlexibleMVC.Web.Controllers" },
                constraints: new { controller = new DefaultRouteConstraint() }
            );

        }

        public static void RegisterViewMaps(SortedDictionary<string, string> ViewMaps)
        {
            ViewMaps.Add("FlexibleMVC.Web", "~/");
            ViewMaps.Add("FlexibleMVC.Web.Admin", "~/FlexibleMVC.Web.Admin/");

            //ViewMaps.Add("FlexibleMVC.Web.Controllers", "~/Views");
            //ViewMaps.Add("FlexibleMVC.Web.Areas.A.Controllers", "~/Areas/A/Views");
            //ViewMaps.Add("FlexibleMVC.Web.Areas.B.Controllers", "~/Areas/B/Views");

            //ViewMaps.Add("FlexibleMVC.Web.Admin.Controllers", "~/FlexibleMVC.Web.Admin/Views");
            //ViewMaps.Add("FlexibleMVC.Web.Admin.Areas.AA.Controllers", "~/FlexibleMVC.Web.Admin/Areas/AA/Views");
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //自定义视图引擎，如改名默认视图路径
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MvcViewEngine());

            RegisterRoutes(RouteTable.Routes);
            RegisterViewMaps(ExecuteViewResult.ViewMaps);
        }
    }


}

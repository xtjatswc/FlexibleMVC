/*
 * 用户： zxs
 * 日期: 2018/5/18
 * 时间: 10:13
 */
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FlexibleMVC.Web
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                namespaces: new string[] { "FlexibleMVC.Web.Controllers" }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //自定义视图引擎，如改名默认视图路径
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MvcViewEngine());

            RegisterRoutes(RouteTable.Routes);
        }
    }

    public class MvcViewEngine : RazorViewEngine
    {
        public MvcViewEngine()
        {
            MasterLocationFormats = new[] 
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shard/{0}.cshtml",
            };
            ViewLocationFormats = MasterLocationFormats;
            PartialViewLocationFormats = MasterLocationFormats;

            AreaMasterLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/FlexibleMVC.Web.Admin/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/FlexibleMVC.Web.Admin/Areas/{2}/Views/Shared/{0}.cshtml",
            };
            AreaViewLocationFormats = AreaMasterLocationFormats;
            AreaPartialViewLocationFormats = AreaMasterLocationFormats;

        }
    }
}

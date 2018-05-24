using FlexibleMVC.Web.RouteConstraint;
using System.Web.Mvc;
using System.Web.Routing;

namespace FlexibleMVC.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //     name: "Frond_Default",
            //     url: "Frond_{controller}/{action}/{id}",
            //     defaults: new
            //     {
            //         controller = "Home",
            //         action = "Index",
            //         id = UrlParameter.Optional
            //     },
            //     namespaces: new string[] { "FlexibleMVC.Web.Frond.Controllers" },
            //     constraints: new { controller = new FrondRouteConstraint() }
            // );

            //routes.MapRoute(
            //    name: "Admin_Default",
            //    url: "Admin_{controller}/{action}/{id}",
            //    defaults: new
            //    {
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional
            //    },
            //    namespaces: new string[] { "FlexibleMVC.Web.Admin.Controllers" },
            //    constraints: new { controller = new AdminRouteConstraint() }
            //);

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}/{*c}",
            //    defaults: new
            //    {
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional
            //    },
            //    namespaces: new string[] { "FlexibleMVC.Web.Controllers" },
            //    constraints: new { controller = new DefaultRouteConstraint() }
            //);

        }
    }
}
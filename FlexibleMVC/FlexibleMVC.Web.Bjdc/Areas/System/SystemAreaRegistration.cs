using System.Web.Mvc;
using System;
using System.Web.Routing;
using System.Web;
using FlexibleMVC.Base;

namespace FlexibleMVC.Web.Bjdc.Areas.System
{
    public class AAreaRegistration : BaseAreaRegistration
    {
        public override string Namespace
        {
            get { return "FlexibleMVC.Web.Bjdc"; }
        }
        public override string ModuleName
        {
            get { return "Bjdc"; }
        }
        public override string AreaName
        {
            get { return "System"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            base.RegisterArea(context);
            MapRoute(
                name: "default",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { area = new MyRouteConstraint() { ModuleName = ModuleName, AreaName = AreaName } }
            );
        }
    }

    public class MyRouteConstraint : BaseModuleAreaRouteConstraint
    {
        public new bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return base.Match(httpContext, route, parameterName, values, routeDirection);
        }
    }
}

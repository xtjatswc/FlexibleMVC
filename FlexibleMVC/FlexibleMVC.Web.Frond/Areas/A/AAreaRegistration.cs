using FlexibleMVC.Base.Mvc;
using FlexibleMVC.Base.Mvc.Constraint;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FlexibleMVC.Web.Frond.Areas.A
{
    public class AAreaRegistration : BaseAreaRegistration
    {
        public override string Namespace
        {
            get { return "FlexibleMVC.Web.Frond"; }
        }
        public override string ModuleName
        {
            get { return "Frond"; }
        }
        public override string AreaName
        {
            get { return "A"; }
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

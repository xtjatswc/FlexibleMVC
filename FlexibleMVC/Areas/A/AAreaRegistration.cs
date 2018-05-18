using System.Web.Mvc;
using System;
using System.Web.Routing;
using System.Web;

namespace FlexibleMVC.Web.Areas.A
{
    public class AAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "A"; }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "A_default",
                url: "A_{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "FlexibleMVC.Web.Areas.A.Controllers" },
                constraints: new { area = new MyRouteConstraint() }
            );
        }
    }

    public class MyRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //获取id的值
            var id = values[parameterName];

            if(route.DataTokens.Count > 0)
            {
                if (route.DataTokens.ContainsKey("area"))
                {
                    if (route.DataTokens["area"].ToString() == "A")
                        return true;
                }
            }

            return false;
        }
    }
}

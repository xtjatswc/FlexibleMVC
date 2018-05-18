using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace FlexibleMVC.Web.RouteConstraint
{
    public class AdminRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string controller = values[parameterName].ToString();

            if (controller.Contains('_'))
                return false;

            return true;
        }
    }

}
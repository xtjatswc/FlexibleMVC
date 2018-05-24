using FlexibleMVC.Base.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace FlexibleMVC.Base
{
    public class BaseRouteConstraint : IRouteConstraint
    {
        public string ModuleName { get; set; }
        public string AreaName { get; set; }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //controller不能含下划线
            if (values["controller"].ToString().IndexOf("_") >= 0)
                return false;

            //校验area是否匹配
            if (route.DataTokens.Count > 0)
            {
                if (route.DataTokens.ContainsKey(MvcConst.AREA_KEY))
                {
                    if (route.DataTokens[MvcConst.AREA_KEY].ToString().Equals(AreaName, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
            }

            return false;
        }
    }
}

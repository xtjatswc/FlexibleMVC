using FlexibleMVC.Base.Mvc.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace FlexibleMVC.Base.Mvc.Constraint
{
    public class BaseAreaRouteConstraint : IRouteConstraint
    {
        public string ModuleName { get; set; }
        public string AreaName { get; set; }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //如果包含module且不为空，则不匹配路由
            if (values.ContainsKey(MvcConst.MODULE_KEY) && !string.IsNullOrEmpty(values[MvcConst.MODULE_KEY].ToString()))
                return false;

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

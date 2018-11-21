using FlexibleMVC.Base.Mvc.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace FlexibleMVC.Base.Mvc.Constraint
{
    public class BaseModuleRouteConstraint : IRouteConstraint
    {
        public string ModuleName { get; set; }
        public string AreaName { get; set; }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //controller不能含下划线
            if (values["controller"].ToString().IndexOf("_") >= 0)
                return false;

            #region 校验module是否匹配
            //module 从url请求时，url中是否包含module信息
            string appPath = httpContext.Request.ApplicationPath;
            if (appPath != "/")
                appPath += "/";
            bool fromUrlHasModule = httpContext.Request.Path.StartsWith(appPath + ModuleName + "_", StringComparison.OrdinalIgnoreCase);

            //module 从分部视图请求时，是否包含module信息           
            object moduleName = "";
            bool fromPartialHasModule = values.TryGetValue(MvcConst.MODULE_KEY, out moduleName);
            fromPartialHasModule = fromPartialHasModule && moduleName != null 
                && moduleName.ToString().Equals(ModuleName, StringComparison.OrdinalIgnoreCase);

            if (!fromUrlHasModule && !fromPartialHasModule)
                return false;
            #endregion

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

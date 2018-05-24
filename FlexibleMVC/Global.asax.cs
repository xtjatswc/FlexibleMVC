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
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //自定义视图引擎，如改名默认视图路径
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MvcViewEngine());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewMapConfig.RegisterViewMaps(ExecuteViewResult.ViewMaps);
        }
    }


}

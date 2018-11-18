using FlexibleMVC.Base.AcResult;
using FlexibleMVC.Base.Mvc.TempDataProvider;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using static FlexibleMVC.Base.JsonConfig.Config;

namespace FlexibleMVC.Base.Ctrller
{
    /// <summary>
    /// 这个类做了两件事情：
    /// 1、如果请求路由中的Controller不存在，则会跳过Controller和action，直接访问视图cshtml,cshtml也不存在，则会报错
    /// 2、修改TempData的提供程序
    /// </summary>
    public class FolderControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllerType = GetControllerType(requestContext, controllerName);
            // 如果controller不存在，替换为FolderController
            if (controllerType == null)
            {
                // 用路由字段动态构建路由变量
                var dynamicRoute = GetViewPath(requestContext);
                controllerName = "Folder";
                requestContext.RouteData.DataTokens["Namespaces"] = new string[] { "FlexibleMVC.LessBase.Ctrller" };
                controllerType = GetControllerType(requestContext, controllerName);
                requestContext.RouteData.Values["Controller"] = controllerName;
                requestContext.RouteData.Values["action"] = "Index";
                requestContext.RouteData.Values["dynamicRoute"] = dynamicRoute;
            }
            IController iController = GetControllerInstance(requestContext, controllerType);

            //修改TempData的提供程序
            var controller = iController as Controller;

            controller.TempDataProvider = TempDataProviderFactory.GetProvider(Global.LessBase.TempDataProvider.ProviderType);

            return iController;
        }

        //protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        //{
        //    //获取构造函数对象
        //    var constructor = controllerType.GetConstructors()[0];
        //    //获取构造函数参数
        //    var param = constructor.GetParameters();
        //    //获取构造函数所需的参数
        //    var paramNames = param.Select(a => {
        //        var serviceType = (ServiceAttribute)(a.ParameterType.GetCustomAttributes(typeof(ServiceAttribute), true)[0]);
        //        var t = Type.GetType(serviceType.ServiceName + ", " + serviceType.ServiceNameSpace, true);
        //        return Activator.CreateInstance(t);
        //    }).ToArray();
        //    IController controller = Activator.CreateInstance(controllerType, paramNames) as Controller;
        //    return controller;
        //}

        private string GetViewPath(RequestContext requestContext)
        {
            string namespaces = (requestContext.RouteData.DataTokens["Namespaces"] as string[])[0];
            string catchall = string.Join("/", requestContext.RouteData.Values.Values).TrimEnd('/');

            return ExecuteViewResult.GetViewPath(namespaces, catchall);
        }
    }
}

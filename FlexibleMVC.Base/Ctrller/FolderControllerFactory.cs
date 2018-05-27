using FlexibleMVC.Base.AcResult;
using System.Web.Mvc;
using System.Web.Routing;

namespace FlexibleMVC.Base.Ctrller
{
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
            IController controller = GetControllerInstance(requestContext, controllerType);
            return controller;
        }

        private string GetViewPath(RequestContext requestContext)
        {
            string namespaces = (requestContext.RouteData.DataTokens["Namespaces"] as string[])[0];
            string catchall = string.Join("/", requestContext.RouteData.Values.Values).TrimEnd('/');

            return ExecuteViewResult.GetViewPath(namespaces, catchall);
        }
    }
}

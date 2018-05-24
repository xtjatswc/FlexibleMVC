using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Filters
{
    public class CheckUserRoleAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            /*
             * 这里为了方便演示，直接在请求参数中获取了userName
             * 假设某一个Action只有Lucy可以访问。
             */
            string userName = filterContext.HttpContext.Request["userName"];
            if (userName == "Lucy")
            {
                base.OnActionExecuting(filterContext);
                return;
            }
            else
            {
                //这里构造了一个心得ActionResult.如果userName不是Lucy，则返回权限不足
                filterContext.Result = new System.Web.Mvc.ContentResult() { Content = "权限不足，无法访问" };
                return;
            }
        }
    }
}
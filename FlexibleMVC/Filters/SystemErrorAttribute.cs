using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;

namespace FlexibleMVC.Web.Filters
{
    /// <summary>
    /// 如果想使用HandleErrorAttribute，customError的mode属性必须为On或RemoteOnly
    /// </summary>
    public class SystemErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            
            //这里是使用log4net来记录
            log4net.ILog log = log4net.LogManager.GetLogger(filterContext.Controller.GetType());
            log.Error(filterContext.Exception);

            //判断是否启用了自定义错误
            if (filterContext.HttpContext.IsCustomErrorEnabled)
            {
                var less = filterContext.Controller as LessBaseController;
                less.TempData["Exception"] = filterContext.Exception;

                //filterContext.Result = new ContentResult() { Content = "系统错误，请联系管理员" };
                //filterContext.Result = new RedirectResult(less.flexibleContext.AppPath + "/Error/CustomError");
            }
        }
    }
}
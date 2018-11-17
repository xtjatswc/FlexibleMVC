using FlexibleMVC.Base.AcResult;
using FlexibleMVC.Base.Context;
using FlexibleMVC.Base.Ctrller;
using FlexibleMVC.Base.JsonConfig;
using FlexibleMVC.Base.Jwt;
using FlexibleMVC.LessBase.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlexibleMVC.LessBase.Filters.Permission
{
    public class CheckUserRoleAttribute : ActionFilterAttribute
    {
        public bool Enabled { get; set; } = true;

        public string WhenNotPassedRedirectUrl { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Enabled)
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            string token = filterContext.HttpContext.Request["token"];
            JwtResult jwt = JwtUtil.Decode(token);
            if (jwt.Success)
            {
                base.OnActionExecuting(filterContext);
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(WhenNotPassedRedirectUrl))
                {
                    filterContext.Result = new BaseJsonResult() { Data = jwt };
                }
                else
                {
                    filterContext.Result = new RedirectResult(WhenNotPassedRedirectUrl);
                }
            }
        }
    }
}
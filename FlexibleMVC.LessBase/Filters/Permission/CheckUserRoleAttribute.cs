using FlexibleMVC.Base.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlexibleMVC.LessBase.Filters.Permission
{
    public class CheckUserRoleAttribute : ActionFilterAttribute
    {
        public bool Passed { get; set; }
        public string WhenNotPassedRedirectUrl { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string token = filterContext.HttpContext.Request["token"];

            JwtResult jwt = JwtUtil.Decode(token);

            if (Passed || jwt.Success)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                if (string.IsNullOrEmpty(WhenNotPassedRedirectUrl))
                {
                    filterContext.Result = new ContentResult() { Content = jwt.ErrInfo };
                }
                else
                {
                    filterContext.Result = new RedirectResult(WhenNotPassedRedirectUrl);
                }
            }
        }
    }
}
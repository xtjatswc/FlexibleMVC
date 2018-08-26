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
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string token = filterContext.HttpContext.Request["token"];

            JwtResult jwt = JwtUtil.Decode(token);
            
            if (jwt.Success)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new System.Web.Mvc.ContentResult() { Content = jwt.ErrInfo };
            }
        }
    }
}
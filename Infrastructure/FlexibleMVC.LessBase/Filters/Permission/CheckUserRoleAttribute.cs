using FlexibleMVC.Base.Context;
using FlexibleMVC.Base.Ctrller;
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
        private bool enabled = true;
        public bool Enabled { get => enabled; set => enabled = value; }

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
                IBaseController baseController = filterContext.Controller as IBaseController;      
                if (baseController != null)
                {
                    baseController.Jwt = jwt;
                }
                base.OnActionExecuting(filterContext);
                return;
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
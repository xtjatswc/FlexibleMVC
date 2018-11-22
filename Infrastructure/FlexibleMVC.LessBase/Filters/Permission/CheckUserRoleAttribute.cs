using FlexibleMVC.Base.Jwt;
using FlexibleMVC.Base.Mvc.AcResult;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;

namespace FlexibleMVC.LessBase.Filters.Permission
{
    public class CheckUserRoleAttribute : ActionFilterAttribute
    {
        public bool Enabled { get; set; } = true;

        public string WhenNotPassedRedirectUrl { get; set; }

        public LessFlexibleContext lessContext => DependencyResolver.Current.GetService<LessFlexibleContext>();

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
                //获取当前登录用户
                IUser iUser = lessContext.GetService<IUser>();
                lessContext.CurrentUser = iUser.GetCurrentUser(lessContext);

                //获取权限
                IPermissions iPermissions = lessContext.GetService<IPermissions>();
                lessContext.Limit = iPermissions.GetPermissions(lessContext, filterContext.RequestContext.HttpContext.Request);

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
using FlexibleMVC.Base.Jwt;
using FlexibleMVC.Base.Mvc.AcResult;
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
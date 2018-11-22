using System.Collections.Generic;
using System.Web;
using FlexibleMVC.Base.Mvc.Ctrller;
using FlexibleMVC.LessBase.Context;

namespace FlexibleMVC.LessBase.Ctrller
{
    public class LessBaseController : BaseController<LessFlexibleContext>
    {
        public LessBaseController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {

        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            flexibleContext.AppPath = requestContext.HttpContext.Request.ApplicationPath.TrimEnd('/');

            base.Initialize(requestContext);
        }
    }

    public interface IPermissions
    {
        Dictionary<string, bool> GetPermissions(LessFlexibleContext flexibleContext, HttpRequestBase Request);
    }

    public interface IUser
    {
        dynamic GetCurrentUser(LessFlexibleContext flexibleContext);
    }
}

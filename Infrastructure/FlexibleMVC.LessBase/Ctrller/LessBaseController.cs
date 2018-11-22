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
            var request = requestContext.HttpContext.Request;
            flexibleContext.AppPath = request.ApplicationPath.TrimEnd('/');

            //获取权限
            IPermissions iPermissions = flexibleContext.GetService<IPermissions>();
            flexibleContext.Limit = iPermissions.GetPermissions(flexibleContext, request);
            base.Initialize(requestContext);
        }
    }

    public interface IPermissions
    {
        Dictionary<string, bool> GetPermissions(LessFlexibleContext flexibleContext, HttpRequestBase Request);
    }
}

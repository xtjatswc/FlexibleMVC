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
            flexibleContext.AppPath = requestContext.HttpContext.Request.ApplicationPath;
            base.Initialize(requestContext);
        }
    }
}

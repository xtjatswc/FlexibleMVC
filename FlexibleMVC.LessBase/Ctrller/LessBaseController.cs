using FlexibleMVC.Base.Ctrller;
using FlexibleMVC.LessBase.Context;

namespace FlexibleMVC.LessBase.Ctrller
{
    public class LessBaseController : BaseController
    {
        public LessFlexibleContext lessContext = new LessFlexibleContext();

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            lessContext.Base = flexibleContext;
        }

    }
}

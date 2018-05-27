using FlexibleMVC.Base.Context;
using FlexibleMVC.LessBase.Ctrller;

namespace FlexibleMVC.LessBase.Context
{
    public class LessContextWebViewPage<TModel> : FlexibleContextWebViewPage<TModel>
    {
        public LessFlexibleContext lessContext;

        public override void InitHelpers()
        {
            base.InitHelpers();
            LessBaseController lessBaseController = ((this.ViewContext.Controller) as LessBaseController);
            if (lessBaseController != null)
            {
                lessContext = lessBaseController.lessContext;               
            }

        }
    }
}

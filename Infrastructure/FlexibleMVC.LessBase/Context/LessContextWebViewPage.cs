using FlexibleMVC.Base.Context;
using FlexibleMVC.LessBase.Ctrller;

namespace FlexibleMVC.LessBase.Context
{
    public class LessContextWebViewPage<TModel> : FlexibleContextWebViewPage<TModel, LessFlexibleContext>
    {
        //public LessFlexibleContext lessContext;

        public override void InitHelpers()
        {
            base.InitHelpers();
            //LessBaseController<LessFlexibleContext> lessBaseController = ((this.ViewContext.Controller) as LessBaseController<LessFlexibleContext>);
            //if (lessBaseController != null)
            //{
            //    lessContext = lessBaseController.flexibleContext;               
            //}

        }
    }
}

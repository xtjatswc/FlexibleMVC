using FlexibleMVC.Base.Ctrller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Base.Context
{
    public class FlexibleContextWebViewPage<TModel, TContext> : System.Web.Mvc.WebViewPage<TModel>
    {

        public TContext flexibleContext;

        public override void Execute()
        {
            
        }

        public override void InitHelpers()
        {
            base.InitHelpers();
            BaseController<TContext> baseController = ((this.ViewContext.Controller) as BaseController<TContext>);
            if (baseController != null)
            {
                flexibleContext = baseController.flexibleContext;
            }

        }

    }
}

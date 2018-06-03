using FlexibleMVC.Base.Ctrller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Base.Context
{
    public class FlexibleContextWebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {

        public FlexibleContext flexibleContext;

        public override void Execute()
        {
            
        }

        public override void InitHelpers()
        {
            base.InitHelpers();
            BaseController baseController = ((this.ViewContext.Controller) as BaseController);
            if (baseController != null)
            {
                flexibleContext = baseController.flexibleContext;
            }

        }

    }
}

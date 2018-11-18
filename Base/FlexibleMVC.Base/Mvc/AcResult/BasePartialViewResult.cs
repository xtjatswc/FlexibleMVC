using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FlexibleMVC.Base.Mvc.AcResult
{
    public class BasePartialViewResult : PartialViewResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(this.ViewName))
            {
                this.ViewName = ExecuteViewResult.GetViewName(context);
            }


            base.ExecuteResult(context);
        }
    }
}

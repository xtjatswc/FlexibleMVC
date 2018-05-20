using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FlexibleMVC.Base
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
                ExecuteViewResult execResult = new ExecuteViewResult();
                this.ViewName = execResult.GetViewName(context);
            }


            base.ExecuteResult(context);
        }
    }
}

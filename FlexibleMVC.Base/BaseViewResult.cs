using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FlexibleMVC.Base
{
    public class BaseViewResult : ViewResult
    {
        public static SortedDictionary<string, string> ViewMaps = new SortedDictionary<string, string>();

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(this.ViewName))
            {
                try
                {
                    string key = (context.RouteData.DataTokens["Namespaces"] as string[])[0];
                    string ViewName = null;

                    if (ViewMaps.TryGetValue(key, out ViewName))
                    {
                        this.ViewName = string.Format("{0}/{1}/{2}.cshtml",
                            ViewName,
                            context.RouteData.GetRequiredString("controller"),
                            context.RouteData.GetRequiredString("action")
                            );
                    }

                }
                catch (Exception)
                {

                    //throw;
                }
            }


            base.ExecuteResult(context);
        }
    }
}

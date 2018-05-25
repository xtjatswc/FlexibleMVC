using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FlexibleMVC.Base.AcResult
{
    public class ExecuteViewResult
    {
        public static SortedDictionary<string, string> ViewMaps = new SortedDictionary<string, string>();

        public string GetViewName(ControllerContext context)
        {
            try
            {
                string namespaces = (context.RouteData.DataTokens["Namespaces"] as string[])[0];

                string ViewFolder = null;
                foreach (var item in ViewMaps.Reverse())
                {
                    if (namespaces.IndexOf(item.Key) >= 0)
                    {
                        ViewFolder = namespaces.Replace(item.Key + ".", "");
                        ViewFolder = ViewFolder.Replace(".", "/");
                        ViewFolder = item.Value + ViewFolder.Replace("Controllers", "Views");
                        break;
                    }
                }

                return string.Format("{0}/{1}/{2}.cshtml",
                    ViewFolder,
                    context.RouteData.GetRequiredString("controller"),
                    context.RouteData.GetRequiredString("action")
                    );

            }
            catch (Exception)
            {

                //throw;
            }

            return null;
        }
    }
}

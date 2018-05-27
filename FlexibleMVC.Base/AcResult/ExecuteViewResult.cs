using System;
using System.Collections.Generic;
using System.Linq;
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
                string controller = context.RouteData.GetRequiredString("controller");
                string action = context.RouteData.GetRequiredString("action");
                return GetViewPath(namespaces, controller, action);
            }
            catch (Exception)
            {
                //throw;
            }

            return null;
        }

        public static string GetViewPath(string namespaces, string controller, string action)
        {
            string ViewFolder = GetViewFolder(namespaces);
            return string.Format("{0}/{1}/{2}.cshtml",
                ViewFolder,
                controller,
                action
                );
        }

        public static string GetViewPath(string namespaces, string catchall)
        {
            string ViewFolder = GetViewFolder(namespaces);
            return string.Format("{0}/{1}.cshtml",
                ViewFolder,
                catchall
                );
        }

        private static string GetViewFolder(string namespaces)
        {
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

            return ViewFolder;
        }
    }
}

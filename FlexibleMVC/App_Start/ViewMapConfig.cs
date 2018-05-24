using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexibleMVC.Web
{
    public class ViewMapConfig
    {
        public static void RegisterViewMaps(SortedDictionary<string, string> ViewMaps)
        {
            ViewMaps.Add("FlexibleMVC.Web", "~/");
            ViewMaps.Add("FlexibleMVC.Web.Admin", "~/FlexibleMVC.Web.Admin/");
            ViewMaps.Add("FlexibleMVC.Web.Frond", "~/FlexibleMVC.Web.Frond/");

            //ViewMaps.Add("FlexibleMVC.Web.Controllers", "~/Views");
            //ViewMaps.Add("FlexibleMVC.Web.Areas.A.Controllers", "~/Areas/A/Views");
            //ViewMaps.Add("FlexibleMVC.Web.Areas.B.Controllers", "~/Areas/B/Views");

            //ViewMaps.Add("FlexibleMVC.Web.Admin.Controllers", "~/FlexibleMVC.Web.Admin/Views");
            //ViewMaps.Add("FlexibleMVC.Web.Admin.Areas.AA.Controllers", "~/FlexibleMVC.Web.Admin/Areas/AA/Views");
        }
    }
}
using System.Web.Mvc;

namespace FlexibleMVC.Base
{
    public class MvcViewEngine : RazorViewEngine
    {
        public MvcViewEngine()
        {
            MasterLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shard/{0}.cshtml",

                //"~/FlexibleMVC.Web.Admin/Views/{1}/{0}.cshtml",
                //"~/FlexibleMVC.Web.Admin/Views/Shared/{0}.cshtml",
            };
            ViewLocationFormats = MasterLocationFormats;
            PartialViewLocationFormats = MasterLocationFormats;

            AreaMasterLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",

                //"~/FlexibleMVC.Web.Admin/Areas/{2}/Views/{1}/{0}.cshtml",
                //"~/FlexibleMVC.Web.Admin/Areas/{2}/Views/Shared/{0}.cshtml",
            };
            AreaViewLocationFormats = AreaMasterLocationFormats;
            AreaPartialViewLocationFormats = AreaMasterLocationFormats;

        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }
    }
}

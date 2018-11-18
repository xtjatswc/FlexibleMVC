using FlexibleMVC.Base.Mvc;
using FlexibleMVC.Base.Mvc.Const;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Admin
{
    public class RootAreaRegistration : BaseAreaRegistration
    {
        public override string Namespace
        {
            get { return "FlexibleMVC.Web.Admin"; }
        }
        public override string ModuleName
        {
            get { return "Admin"; }
        }
        public override string AreaName
        {
            get { return MvcConst.ROOT_AREANAME; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            base.RegisterArea(context);
            MapRoute(
                name: "default",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

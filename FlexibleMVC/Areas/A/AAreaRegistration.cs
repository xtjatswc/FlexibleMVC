using FlexibleMVC.Base.Mvc;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Areas.A
{
    public class AAreaRegistration : BaseAreaRegistration
    {
        public override string Namespace
        {
            get { return "FlexibleMVC.Web"; }
        }
        public override string ModuleName
        {
            get { return ""; }
        }
        public override string AreaName
        {
            get { return "A"; }
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

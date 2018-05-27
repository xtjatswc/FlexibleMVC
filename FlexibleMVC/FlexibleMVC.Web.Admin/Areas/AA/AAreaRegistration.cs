using System.Web.Mvc;
using System;
using FlexibleMVC.Base;

namespace FlexibleMVC.Web.Admin.Areas.AA
{
	public class AAreaRegistration : BaseAreaRegistration
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
            get { return "AA"; }
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

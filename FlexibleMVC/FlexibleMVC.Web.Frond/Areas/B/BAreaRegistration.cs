using System.Web.Mvc;
using System;
using System.Web.Routing;
using System.Web;
using FlexibleMVC.Base;

namespace FlexibleMVC.Web.Frond.Areas.B
{
    public class BAreaRegistration : BaseAreaRegistration
    {
        public override string Namespace
        {
            get { return "FlexibleMVC.Web.Frond"; }
        }
        public override string ModuleName
        {
            get { return "Frond"; }
        }
        public override string AreaName
        {
            get { return "B"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            base.RegisterArea(context);
            MapRoute(
                name: "default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

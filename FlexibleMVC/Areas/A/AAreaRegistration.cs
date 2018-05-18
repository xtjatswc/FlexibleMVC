using System.Web.Mvc;
using System;

namespace FlexibleMVC.Areas.A
{
	public class AAreaRegistration : AreaRegistration
	{
		public override string AreaName {
			get { return "A"; }
		}
		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				name : "A_default",
				url : "A/{controller}/{action}/{id}",
				defaults : new { controller = "Home", action = "Index", id = UrlParameter.Optional},
				namespaces : new string[]{"FlexibleMVC.Areas.A.Controllers"}
			);
		}
	}
}

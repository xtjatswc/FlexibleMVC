using System.Web.Mvc;
using System;

namespace FlexibleMVC.Web.Admin.Areas.AA
{
	public class AAreaRegistration : AreaRegistration
	{
		public override string AreaName {
			get { return "AA"; }
		}
		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				name : "Admin_AA_default",
				url : "Admin/AA/{controller}/{action}/{id}",
				defaults : new { controller = "Home", action = "Index", id = UrlParameter.Optional},
				namespaces : new string[]{"FlexibleMVC.Web.Admin.Areas.AA.Controllers"}
			);
		}
	}
}

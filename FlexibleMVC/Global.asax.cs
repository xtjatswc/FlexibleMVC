/*
 * 用户： zxs
 * 日期: 2018/5/18
 * 时间: 10:13
 */
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FlexibleMVC
{
	public class MvcApplication : HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.Ignore("{resource}.axd/{*pathInfo}");
			
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new {
					controller = "Home",
					action = "Index",
					id = UrlParameter.Optional
				},
				namespaces : new string[]{ "FlexibleMVC.Controllers" }
			);
		}
		
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);
		}
	}
}

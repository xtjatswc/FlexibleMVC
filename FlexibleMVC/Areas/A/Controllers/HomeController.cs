/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using System;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Areas.A.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
		
		public ActionResult Contact()
		{
			return View("~/Areas/A/Views/Home/Contact.cshtml");
		}

        public ActionResult GotoB()
        {
            return RedirectToRoute("B_default", new { controller = "Home", Action = "Index", para = 1 });
        }

        public ActionResult Part2()
        {
            return View();
        }

    }
}

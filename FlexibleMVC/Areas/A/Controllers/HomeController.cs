/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using System;
using System.Web.Mvc;

namespace FlexibleMVC.Areas.A.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
		
		public ActionResult Contact()
		{
			return View();
		}
	}
}

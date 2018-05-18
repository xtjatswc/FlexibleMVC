/*
 * 用户： zxs
 * 日期: 2018/5/18
 * 时间: 10:13
 */
using System;
using System.Web.Mvc;

namespace FlexibleMVC.Controllers
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

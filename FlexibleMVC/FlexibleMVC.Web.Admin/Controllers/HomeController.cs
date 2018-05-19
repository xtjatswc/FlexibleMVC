/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.Base;
using System;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Admin.Controllers
{
	public class HomeController : BaseController
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

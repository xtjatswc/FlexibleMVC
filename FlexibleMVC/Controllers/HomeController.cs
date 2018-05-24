/*
 * 用户： zxs
 * 日期: 2018/5/18
 * 时间: 10:13
 */
using FlexibleMVC.Base;
using FlexibleMVC.Web.Filters;
using System;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Controllers
{
	public class HomeController : BaseController
    {
		public ActionResult Index(string id = null, string c = null)
		{
			return View();
		}

        public ActionResult Contact()
        {
            return View();
        }

        public PartialViewResult Part2()
        {
            return PartialView();
        }

        [CheckUserRole]
        public ActionResult SayHello()
        {
            return Content("我是Lucy，这只能给我访问");
        }

    }
}

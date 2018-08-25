﻿/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.Base.Ctrller;
using System.Web.Mvc;
using FlexibleMVC.Base.Context;
using FlexibleMVC.LessBase.Context;

namespace FlexibleMVC.Web.Admin.Controllers
{
    public class HomeController : BaseController<FlexibleContext>
    {
        public HomeController(FlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        public ActionResult Index()
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
    }
}

/*
 * 用户： zxs
 * 日期: 2018/5/18
 * 时间: 10:13
 */
using FlexibleMVC.LessBase.Ctrller;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Context;

namespace FlexibleMVC.Web.Bjdc.Controllers
{
    public class HomeController : LessBaseController
    {
        public HomeController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

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


    }
}

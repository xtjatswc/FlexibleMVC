/*
 * 用户： zxs
 * 日期: 2018/5/18
 * 时间: 10:13
 */
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.Web.Filters;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Context;

namespace FlexibleMVC.Web.Controllers
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
            flexibleContext.log.Debug("访问了根目录的 Home Contact");
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

        [SystemError]//添加
        public ActionResult MyError()
        {
            //人为制造一个错误
            int a = 1;
            int b = 0;
            return Content((a / b).ToString());
        }
    }
}

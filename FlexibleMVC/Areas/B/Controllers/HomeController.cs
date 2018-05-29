/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.LessBase.Ctrller;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Areas.B.Controllers
{
    public class HomeController : LessBaseController
    {
		public ActionResult Index()
		{
			return View();
		}
		
		public ActionResult Contact()
		{
			return View();
		}

        public ActionResult Contact2(string hehe)
        {
            return Content("来自B模块" + hehe);
        }

        public ActionResult GotoFrondA()
        {
            //return RedirectToAction("contact", "home", new { module = "frond", area = "a" });
            return RedirectToRoute("frond_a_default", new {module="frond", area="a", controller = "home", action = "contact" });
        }
    }
}

/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.LessBase.Ctrller;
using System.Web.Mvc;
using FlexibleMVC.BLL;

namespace FlexibleMVC.Web.Frond.Areas.B.Controllers
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

        public PartialViewResult Part2()
        {
            return PartialView();
        }

        public JsonResult GetModels()
        {
            var bll = lessContext.Get<PatientBll>();
            var models = bll.dal.GetModels(currentPage: 2, itemsPerPage: 2);
            return Json(models);
        }
    }
}

/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.LessBase.Ctrller;
using System.Web.Mvc;
using FlexibleMVC.BLL;
using FlexibleMVC.Model;

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
            var model = bll.dal.GetModel(13851);
            var models = bll.dal.GetDataTable();

            //lessContext.db.Insert<PatientBasicInfo>("PatientBasicInfo", model)
            //    .AutoMap(x => x.PATIENT_DBKEY)
            //    .ExecuteReturnLastId<int>();
            bll.dal.Delete(13860);

            return Json(models);
        }
    }
}

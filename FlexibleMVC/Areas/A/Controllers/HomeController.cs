/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.LessBase.Ctrller;
using System.Data;
using System.Dynamic;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Areas.A.Controllers
{
    [OutputCache(Duration = 10)]
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

        public ActionResult GotoB()
        {
            return RedirectToRoute("B_default", new { controller = "Home", Action = "Index", para = 1 });
        }

        public PartialViewResult Part2()
        {
            return PartialView();
        }

        public JsonResult GetJson()
        {
            dynamic obj = new ExpandoObject();
            //添加属性
            obj.name = "Li Lei";
            obj.age = 20;
            obj.color = new { color1 = "red", color2 = "green" };
            return Json(obj);
        }

        public JsonResult TestMysql()
        {
            DataTable department = lessContext.db.Sql(@"select * from patientbasicinfo limit 30 ").QuerySingle<DataTable>();
            return Json(department);
        }

        public FileResult TestExcel()
        {
            DataTable department = lessContext.db.Sql(@"select * from patientbasicinfo limit 30 ").QuerySingle<DataTable>();
            return Excel("科室信息导出", department);
        }

        public ActionResult TestXml()
        {
            dynamic obj = new ExpandoObject();
            obj.success = true;
            obj.url = "";

            //DataTable obj = lessContext.db.Sql(@"select * from patientbasicinfo limit 30 ").QuerySingle<DataTable>();
            return Xml(obj);
        }


        public ActionResult GetOther()
        {
            var otherController = DependencyResolver.Current.GetService<FlexibleMVC.Web.Areas.B.Controllers.HomeController>();
            var result = otherController.Contact2("嘿嘿");
            return result;
        }

        public JsonResult TestAjax(FormCollection form)
        {
            dynamic obj = new ExpandoObject();
            obj.success = true;
            obj.url = "";

            return Json(obj);
        }
    }
}

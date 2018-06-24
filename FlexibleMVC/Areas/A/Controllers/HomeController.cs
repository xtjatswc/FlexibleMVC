/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.Base.Filter;
using FlexibleMVC.Base.Jwt;
using FlexibleMVC.Base.Tools;
using FlexibleMVC.BLL;
using FlexibleMVC.LessBase.Ctrller;
using System.Collections.Generic;
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

        public JsonResult Login()
        {
            var dict = new Dictionary<string, object>();
            dict["limit"] = "10101010100111";
            string jwt = JwtUtil.Encode(dict, 10*60);

            JwtResult result = JwtUtil.Decode(jwt);

            return Json(jwt);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Report()
        {
            return Pdf(viewName:"report2", isDownload:false, fileName:"肠内医嘱单");
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

        public JsonResult TestDyn()
        {
            var obj = lessContext.db.Sql(@"select * from patientbasicinfo limit 30 ").QueryMany<dynamic>();

            return Json(obj);
        }

        public ActionResult TestXml()
        {
            var patientBll = lessContext.Get<PatientBll>();
            var list = patientBll.dal.GetModels();

            var obj = new {department = "肿瘤内科", code="0123" , list = list};
            var list2 = new { name = "abc", abe = 1243, department = obj };
            var list3 = patientBll.dal.GetModel(13845);

            return Xml(new { a = 12, patient = list, list3 = list3 });
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
            obj.url = "abc";

            return Json(obj);
        }
    }
}

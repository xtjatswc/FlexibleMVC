/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.DAL;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.Model;
using FluentData;
using System.Data;
using System.Dynamic;
using System.Web.Mvc;
using System.Xml;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.LessBase.Infrastructure;
using System.Collections.Generic;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Controllers
{
    [CheckUserRole(Enabled = false)]
    public class HomeController : LessBaseController
    {
        public HomeController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetListTree()
        {
            var tree = new List<object>()
            {
                new {id = "base", text = "系统导航", pid=""},
                new {id = "ajax", text = "菜品分类管理", pid = "base", url="bjdc_system_MealMenu"}
            };
            return Json(tree);
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
            IDbContext db = new DbContext().ConnectionStringName("testDBContext", new MySqlProvider());
            DataTable department = db.Sql(@"select * from patientbasicinfo limit 30 ").QuerySingle<DataTable>();
            return Json(department);
        }

        public ActionResult TestToJson()
        {
            var dal = new BaseDAL<ChinaFoodComposition>(flexibleContext) { Db = flexibleContext.db};
            return Content(dal.GetModel(10002).ToJson());
        }
    }
}

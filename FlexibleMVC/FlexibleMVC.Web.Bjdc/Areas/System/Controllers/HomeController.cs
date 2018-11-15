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
using FlexibleMVC.BLL.Admin.Permissions;
using FlexibleMVC.Model.Admin.Permissions;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Controllers
{
    public class HomeController : LessBaseController
    {
        public HomeController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        [CheckUserRole(WhenNotPassedRedirectUrl = "/bjdc_system_login")]
        public ActionResult Index()
        {
            SysUserBll sysUserBll = flexibleContext.GetService<SysUserBll>();
            SysUser sysUser = sysUserBll.getCurrentUser();
            if (sysUser == null)
                return RedirectPermanent("/bjdc_system_login");

            return View(sysUser);
        }

        public JsonResult GetListTree()
        {
            var tree = new List<object>()
            {
                new {id = "1", text = "系统导航", pid=""},
                new {id = "2", text = "菜品分类管理", pid = "1", url="/bjdc_system_MealCategory/index"},
                new {id = "3", text = "菜单管理", pid = "1", url="/bjdc_system_MealMenu/index"},
                new {id = "4", text = "一周食谱计划", pid = "1", url="/bjdc_system_MealSchedule/index"},
                new {id = "5", text = "订单查询", pid = "1", url="/bjdc_system_MealOrder/index"}
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

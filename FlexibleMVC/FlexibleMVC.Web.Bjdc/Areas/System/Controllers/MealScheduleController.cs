using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.Web.Bjdc.Areas.System.DAL;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Controllers
{
    [CheckUserRole(Enabled = false)]
    public class MealScheduleController : LessBaseController
    {
        public MealScheduleController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetWeekTree()
        {
            var mealDictDal = flexibleContext.GetService<MealDictDal>();
            var lstMenu = mealDictDal.GetModels(where: "ItemType='菜单计划'", orderBy:"sortNo asc");
            var lstTimes = mealDictDal.GetModels(where: "ItemType='餐别'", orderBy: "sortNo asc");

            var tree = new List<object>
            {
                new { id = "0", text = "一周计划", pid = "" }
            };

            foreach (var menu in lstMenu)
            {
                tree.Add(new { id = menu.ItemID, text = menu.ItemName, pid = "0" });
                foreach (var time in lstTimes)
                {
                    tree.Add(new { id = time.ItemID, text = time.ItemName, pid = menu.ItemID });
                }
            }

            return Json(tree);
        }
    }
}

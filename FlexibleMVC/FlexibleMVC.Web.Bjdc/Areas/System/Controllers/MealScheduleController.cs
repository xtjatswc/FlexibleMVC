using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.Web.Bjdc.Areas.System.DAL;
using FlexibleMVC.Web.Bjdc.Areas.System.Model;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Controllers
{
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
                tree.Add(new { id = menu.ItemID, text = menu.ItemName, pid = "0", code=menu.ItemValue });
                foreach (var time in lstTimes)
                {
                    tree.Add(new { id = time.ItemID, text = time.ItemName, pid = menu.ItemID, code=time.ItemValue,week = menu.ItemValue });
                }
            }

            return Json(tree);
        }

        public JsonResult SaveSchedule()
        {
            var data = GetArrayList("data");
            int week = GetInt("week");
            long MealTimesCode = GetInt("MealTimesCode");
            string MealTimesName = GetString("MealTimesName");

            var mealScheduleDal = flexibleContext.GetService<MealScheduleDal>();
            mealScheduleDal.Db.Sql("delete from dc_mealschedule where DayOfWeek = @0 and MealTimesCode = @1", week,
                MealTimesCode).Execute();
            foreach (var o in data)
            {
                MealSchedule model = new MealSchedule();
                model.MealTimesCode = MealTimesCode;
                model.MealTimesName = MealTimesName;
                model.DayOfWeek = week;
                model.MealMenuID = Convert.ToInt32(o["ItemID"].ToString().Split('_')[1]);
                mealScheduleDal.Insert(model);
            }            

            var result = new { };
            return Json(result);
        }
    }
}

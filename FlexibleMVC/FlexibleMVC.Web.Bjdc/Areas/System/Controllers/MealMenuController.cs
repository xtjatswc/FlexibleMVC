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
    public class MealMenuController : LessBaseController
    {

        public MealMenuController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategoryList()
        {
            var mealDictDal = flexibleContext.GetService<MealDictDal>();
            var models = mealDictDal.GetModels(where:"ItemType='菜品分类'");
            var result = new { total = 20, data = models };
            return Json(result);
        }

    }
}

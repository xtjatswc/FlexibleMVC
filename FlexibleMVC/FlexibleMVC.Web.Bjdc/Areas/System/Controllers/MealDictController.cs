using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.Web.Bjdc.Areas.System.DAL;
using FlexibleMVC.Web.Bjdc.Areas.System.Model;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Controllers
{
    public class MealDictController : LessBaseController
    {
        public MealDictController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        public ActionResult GetMealIimes()
        {
            MealDictDal mealDictDal = flexibleContext.GetService<MealDictDal>();
            var models = mealDictDal.GetModels(DictItemType.餐别);

            return Json(models);
        }

    }
}

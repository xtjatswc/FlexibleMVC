using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Web.Bjdc.Areas.System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlexibleMVC.LessBase.Context;

namespace FlexibleMVC.Web.Bjdc.Areas.System.DAL
{
    public class MealScheduleDal : BaseDAL<MealSchedule>
    {
        public MealScheduleDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db;
        }

        public SortedDictionary<long, MealSchedule> GetSchedule(string week, string mealTimesCode)
        {
            var lstSchedule = GetModels(where: "DayOfWeek = '" + week + "' and MealTimesCode = '" + mealTimesCode + "'");
            var dict = new SortedDictionary<long, MealSchedule>();
            foreach (var model in lstSchedule)
            {
                dict.Add(model.MealMenuID, model);
            }

            return dict;
        }

    }

}
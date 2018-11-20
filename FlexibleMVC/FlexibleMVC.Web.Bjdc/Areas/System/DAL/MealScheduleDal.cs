using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Web.Bjdc.Areas.System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Extension;

namespace FlexibleMVC.Web.Bjdc.Areas.System.DAL
{
    public class MealScheduleDal : BaseDAL<MealSchedule>
    {
        public MealScheduleDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db;
        }

        public SortedSet<long> GetSchedule(string week, string mealTimesCode)
        {
            var models = Db
                .Sql("select MealMenuID from dc_MealSchedule where DayOfWeek = @DayOfWeek and MealTimesCode = @mealTimesCode")
                .Parameter("DayOfWeek", week).Parameter("MealTimesCode", mealTimesCode).QueryMany<long>().ToSortedSet();

            return models;
        }

    }

}
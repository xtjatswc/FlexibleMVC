using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlexibleMVC.LessBase.Infrastructure.Attribute;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Model
{
    [TableName("dc_mealschedule")]
    public class MealSchedule
    {
        [PrimaryKey()]
        public Int64 ID { get; set; }
        public Int32 DayOfWeek { get; set; }
        public Int64 MealTimesCode { get; set; }
        public String MealTimesName { get; set; }
        public Int64 MealMenuID { get; set; }
    }
}
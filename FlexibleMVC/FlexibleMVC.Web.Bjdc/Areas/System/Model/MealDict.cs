using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Infrastructure.Attribute;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Model
{
    [TableName("dc_mealdict")]
    public class MealDict
    {
        [PrimaryKey()]
        public Int64 ItemID { get; set; }
        public String ItemName { get; set; }
        public String ItemValue { get; set; }
        public String ItemType { get; set; }
        public Decimal SortNo { get; set; }
        public Int32 IsAllowedEdit { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlexibleMVC.LessBase.Infrastructure.Attribute;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Model
{
    [TableName("dc_MealMenu")]
    public class MealMenu
    {
        [PrimaryKey()]
        public Int64 MealMenuID { get; set; }
        public String SaleName { get; set; }
        public Decimal SalePrice { get; set; }
        public Decimal SortNo { get; set; }
        public Int64 CategoryID { get; set; }
        public DateTime CreateTime { get; set; }
        public String CreateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public String UpdateBy { get; set; }
    }
}
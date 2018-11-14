using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlexibleMVC.LessBase.Infrastructure.Attribute;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Model
{
    [TableName("dc_mealorder")]
    public class MealOrder
    {
        [PrimaryKey()]
        public Int64 OrderID { get; set; }
        public DateTime OrderTime { get; set; }
        public String ContactName { get; set; }
        public String ContactMobile { get; set; }
        public String DepartmentName { get; set; }
        public String BedCode { get; set; }
        public Int32 IsAlreadyPaid { get; set; }
        public DateTime PayTime { get; set; }
        public String PayNo { get; set; }
        public Decimal OrderMoney { get; set; }
    }
}
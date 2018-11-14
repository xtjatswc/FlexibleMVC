using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlexibleMVC.LessBase.Infrastructure.Attribute;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Model
{
    [TableName("dc_mealorderdetail")]
    public class MealOrderDetail
    {
        [PrimaryKey()]
        public Int64 OrderDetailID { get; set; }
        public Int64 OrderID { get; set; }
        public String SaleName { get; set; }
        public Decimal SalePrice { get; set; }
        public Int32 SaleNum { get; set; }
        public Decimal SaleMoney { get; set; }
        public DateTime MealDate { get; set; }
        public String MealTimesName { get; set; }

    }
}
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
    public class MealOrderDetailController : LessBaseController
    {
        public MealOrderDetailController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        public JsonResult GetOrderDetailList()
        {
            //查询条件
            //string SaleName = Request.GetSqlParamer("SaleName");
            string OrderID = GetString("OrderID");

            //分页
            int pageIndex = GetInt("pageIndex") + 1;
            int pageSize = GetInt("pageSize");
            //字段排序
            //String sortField = GetString("sortField");
            //String sortOrder = GetString("sortOrder");

            string sWhere = "OrderID=" + OrderID;

            var mealOrderDetailDal = flexibleContext.GetService<MealOrderDetailDal>();

            var models = mealOrderDetailDal.GetModels(where: sWhere, currentPage: pageIndex, itemsPerPage: pageSize, orderBy: "MealDate asc,MealTimesName asc");
            var count = mealOrderDetailDal.GetCount(where: sWhere);

            var result = new { total = count, data = models };
            return Json(result);
        }
    }
}
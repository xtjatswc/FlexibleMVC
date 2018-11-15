using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.Web.Bjdc.Areas.System.DAL;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Controllers
{
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

        public ActionResult Production()
        {
            return View();
        }

        public JsonResult GetProductionPlan()
        {
            //查询条件
            string mealDate = Request.GetSqlParamer("MealDate");
            string mealTimes = GetString("MealTimes");

            //分页
            int pageIndex = GetInt("pageIndex");
            int pageSize = GetInt("pageSize");
            //字段排序
            //String sortField = GetString("sortField");
            //String sortOrder = GetString("sortOrder");

            string sWhere = "where MealDate='" + mealDate + "'";
            if (mealTimes != "")
            {
                sWhere += " and MealTimesName = '" + mealTimes + "'";
            }

            var mealOrderDetailDal = flexibleContext.GetService<MealOrderDetailDal>();

            var models = mealOrderDetailDal.Db.Sql(@"select MealDate,MealTimesName,SaleName, count(*) SaleNum from dc_mealorderdetail " + sWhere + @"
                group by MealDate,MealTimesName,SaleName
                order by MealDate desc,MealTimesName limit @pageIndex, @pageSize")
                    .Parameter("pageIndex", pageIndex)
                    .Parameter("pageSize", pageSize)
                    .QueryMany<dynamic>();

            var count = mealOrderDetailDal.Db.Sql(@"select count(*) from (
select MealDate,MealTimesName,SaleName, count(*) SaleNum from dc_mealorderdetail " + sWhere + @" group by MealDate,MealTimesName,SaleName) tb")
                .QuerySingle<int>();

            var result = new { total = count, data = models };
            return Json(result);
        }
    }
}
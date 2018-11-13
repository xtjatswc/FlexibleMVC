using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Web.Bjdc.Areas.System.DAL;
using FlexibleMVC.Web.Bjdc.Areas.System.Model;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Controllers
{
    [CheckUserRole(Enabled = false)]
    public class MealMenuController : LessBaseController
    {
        public MealMenuController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMenuList()
        {
            //查询条件
            string SaleName = Request.GetSqlParamer("SaleName");
            string CategoryID = GetString("CategoryID");
            //分页
            int pageIndex = GetInt("pageIndex") + 1;
            int pageSize = GetInt("pageSize");
            //字段排序
            String sortField = GetString("sortField");
            String sortOrder = GetString("sortOrder");

            string sWhere = "CategoryID='"+ CategoryID + "' and SaleName like '%" + SaleName + "%'";

            var mealMenuDal = flexibleContext.GetService<MealMenuDal>();
            var models = mealMenuDal.GetModels(where: sWhere, orderBy: "SortNo asc", currentPage: pageIndex, itemsPerPage: pageSize);
            var count = mealMenuDal.GetCount(where: sWhere);

            var result = new { total = count, data = models };
            return Json(result);
        }
    }
}
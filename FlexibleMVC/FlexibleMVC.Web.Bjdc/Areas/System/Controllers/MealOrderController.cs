using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.Web.Bjdc.Areas.System.DAL;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Controllers
{
    [CheckUserRole(Enabled = false)]
    public class MealOrderController : LessBaseController
    {
        public MealOrderController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetOrderList()
        {
            //查询条件
            //string SaleName = Request.GetSqlParamer("SaleName");
            //string CategoryID = GetString("CategoryID");
            //分页
            int pageIndex = GetInt("pageIndex") + 1;
            int pageSize = GetInt("pageSize");
            //字段排序
            //String sortField = GetString("sortField");
            //String sortOrder = GetString("sortOrder");

            //string sWhere = "CategoryID='" + CategoryID + "' and SaleName like '%" + SaleName + "%'";

            var mealMenuDal = flexibleContext.GetService<MealOrderDal>();

            var models = mealMenuDal.GetModels(where: "", currentPage: pageIndex, itemsPerPage: pageSize, orderBy:"OrderID desc");
            var count = mealMenuDal.GetCount(where: "");

            var result = new { total = count, data = models };
            return Json(result);
        }

    }
}
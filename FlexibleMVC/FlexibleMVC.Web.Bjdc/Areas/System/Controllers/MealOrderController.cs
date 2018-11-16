using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.Web.Bjdc.Areas.System.DAL;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Extension;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Controllers
{
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
            string ContactMobile = Request.GetSqlParamer("ContactMobile");
            string ContactName = Request.GetSqlParamer("ContactName");
            //分页
            int pageIndex = Request.GetInt("pageIndex") + 1;
            int pageSize = Request.GetInt("pageSize");
            //字段排序
            //String sortField = GetString("sortField");
            //String sortOrder = GetString("sortOrder");

            string sWhere = "ContactMobile like '%" + ContactMobile + "%' and ContactName like '%" + ContactName + "%'";

            var mealMenuDal = flexibleContext.GetService<MealOrderDal>();

            var models = mealMenuDal.GetModels(where: sWhere, currentPage: pageIndex, itemsPerPage: pageSize, orderBy:"OrderID desc");
            var count = mealMenuDal.GetCount(where: sWhere);

            var result = new { total = count, data = models };
            return Json(result);
        }

    }
}
using System;
using System.Collections;
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

            string sWhere = "CategoryID='" + CategoryID + "' and SaleName like '%" + SaleName + "%'";

            var mealMenuDal = flexibleContext.GetService<MealMenuDal>();
            var models = mealMenuDal.GetModels(where: sWhere, orderBy: "SortNo asc", currentPage: pageIndex, itemsPerPage: pageSize);
            var count = mealMenuDal.GetCount(where: sWhere);

            var result = new { total = count, data = models };
            return Json(result);
        }

        /// <summary>
        /// 生成带目录的菜单，结构为TreeGrid
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMenuTreeList()
        {
            string week = GetString("week");
            string MealTimesCode = GetString("MealTimesCode");

            var mealDictDal = flexibleContext.GetService<MealDictDal>();
            var lstCategory = mealDictDal.GetModels(where: "ItemType='菜品分类'", orderBy: "SortNo asc");

            var mealMenuDal = flexibleContext.GetService<MealMenuDal>();
            var lstMenu = mealMenuDal.GetModels(orderBy: "SortNo asc");

            var mealScheduleDal = flexibleContext.GetService<MealScheduleDal>();
            var dictSchedule = mealScheduleDal.GetSchedule(week, MealTimesCode);

            //菜品分类
            var lstResult = new List<Object>();
            foreach (var category in lstCategory)
            {
                lstResult.Add(new
                    {ItemID = category.ItemID, ItemName = category.ItemName, ParentItemID = -1, SalePrice = ""});
            }

            //菜单
            foreach (var menu in lstMenu)
            {
                var menuObj = new
                {
                    ItemID = menu.CategoryID + "_" + menu.MealMenuID,
                    ItemName = menu.SaleName,
                    ParentItemID = menu.CategoryID,
                    SalePrice = menu.SalePrice,
                    Checked = dictSchedule.ContainsKey(menu.MealMenuID)
                };

                lstResult.Add(menuObj);
            }

            return Json(lstResult);
        }

        public JsonResult SaveMenu()
        {
            var data = GetArrayList("data");
            var mealMenuDal = flexibleContext.GetService<MealMenuDal>();

            for (int i = 0, l = data.Count; i < l; i++)
            {
                Hashtable o = (Hashtable)data[i];

                String id = o["id"] != null ? o["id"].ToString() : "";
                //根据记录状态，进行不同的增加、删除、修改操作
                String state = o["_state"] != null ? o["_state"].ToString() : "";
                String saleName = o["SaleName"].ToString();
                decimal salePrice = Convert.ToDecimal(o["SalePrice"]);
                long categoryID = Convert.ToInt64(o["CategoryID"].ToString());
                String mealMenuID = o["MealMenuID"] != null ? o["MealMenuID"].ToString() : "";
                decimal sortNo = Convert.ToDecimal(o["SortNo"]);

                if (state == "added" || mealMenuID == "")           //新增：id为空，或_state为added
                {
                    MealMenu model = new MealMenu();
                    model.CategoryID = categoryID;
                    model.CreateBy = "系统管理员";
                    model.CreateTime = DateTime.Now;
                    model.SaleName = saleName;
                    model.SalePrice = salePrice;
                    model.SortNo = sortNo;
                    mealMenuDal.InsertReturnLastId(model, x => x.MealMenuID);
                }
                else if (state == "removed" || state == "deleted")
                {
                    mealMenuDal.Delete(mealMenuID);
                }
                else if (state == "modified" || state == "") //更新：_state为空或modified
                {
                    var model = mealMenuDal.GetModel(mealMenuID);
                    model.SaleName = saleName;
                    model.SalePrice = salePrice;
                    model.SortNo = sortNo;
                    model.UpdateBy = "";
                    model.UpdateTime = DateTime.Now;
                    mealMenuDal.Update(model, x => x.MealMenuID);
                }

                //if (i == 2) throw new Exception("aaa");

            }

            var result = new { };
            return Json(result);
        }
    }
}
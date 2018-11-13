using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.Web.Bjdc.Areas.System.DAL;
using FlexibleMVC.Web.Bjdc.Areas.System.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Extension;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Controllers
{
    [CheckUserRole(Enabled = false)]
    public class MealCategoryController : LessBaseController
    {

        public MealCategoryController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategoryList()
        {
            //查询条件
            string key = Request.GetSqlParamer("key");
            //分页
            int pageIndex = GetInt("pageIndex") + 1;
            int pageSize = GetInt("pageSize");
            //字段排序
            String sortField = GetString("sortField");
            String sortOrder = GetString("sortOrder");

            string sWhere = "ItemType='菜品分类' and ItemName like '%" + key + "%'";

            var mealDictDal = flexibleContext.GetService<MealDictDal>();
            var models = mealDictDal.GetModels(where: sWhere, orderBy:"SortNo asc", currentPage: pageIndex, itemsPerPage: pageSize);
            var count = mealDictDal.GetCount(where: sWhere);

            var result = new { total = count, data = models };
            return Json(result);
        }

        public JsonResult SaveCategory()
        {
            var data = GetArrayList("data");
            var mealDictDal = flexibleContext.GetService<MealDictDal>();

            for (int i = 0, l = data.Count; i < l; i++)
            {
                Hashtable o = (Hashtable)data[i];

                String id = o["id"] != null ? o["id"].ToString() : "";
                //根据记录状态，进行不同的增加、删除、修改操作
                String state = o["_state"] != null ? o["_state"].ToString() : "";
                String itemName = o["ItemName"].ToString();
                String itemID = o["ItemID"] != null ? o["ItemID"].ToString() : "";
                decimal sortNo = Convert.ToDecimal(o["SortNo"]);

                if (state == "added" || itemID == "")           //新增：id为空，或_state为added
                {
                    //o["ItemName"] = DateTime.Now;
                    //employeeDal.Insert(o);
                    MealDict model = new MealDict();
                    model.IsAllowedEdit = 1;
                    model.ItemName = itemName;
                    model.ItemType = "菜品分类";
                    model.ItemValue = null;
                    model.SortNo = sortNo;
                    mealDictDal.InsertReturnLastId(model, x => x.ItemID);
                }
                else if (state == "removed" || state == "deleted")
                {
                    mealDictDal.Delete(itemID);
                }
                else if (state == "modified" || state == "") //更新：_state为空或modified
                {
                    var model = mealDictDal.GetModel(itemID);
                    model.ItemName = itemName;
                    model.SortNo = sortNo;
                    mealDictDal.Update(model, x=>x.ItemID);
                }

                //if (i == 2) throw new Exception("aaa");

            }

            var result = new {};
            return Json(result);
        }

        public JsonResult GetMealMenuTree()
        {
            var mealDictDal = flexibleContext.GetService<MealDictDal>();
            var lstMenu = mealDictDal.GetModels(where: "ItemType='菜品分类'", orderBy:"SortNo asc");

            var tree = new List<object>
            {
                new { id = "0", text = "菜品分类", pid = "" }
            };

            foreach (var menu in lstMenu)
            {
                tree.Add(new { id = menu.ItemID, text = menu.ItemName, pid = "0" });
            }
           
            return Json(tree);
        }

    }
}

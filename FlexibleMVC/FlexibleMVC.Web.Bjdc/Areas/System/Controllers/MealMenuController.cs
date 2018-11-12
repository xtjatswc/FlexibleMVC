using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.Web.Bjdc.Areas.System.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using FlexibleMVC.Base.JsonConfig;
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

        public JsonResult GetCategoryList()
        {
            //查询条件
            string key = GetString("key");
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

                if (state == "added" || id == "")           //新增：id为空，或_state为added
                {
                    //o["ItemName"] = DateTime.Now;
                    //employeeDal.Insert(o);
                    MealDict model = new MealDict();
                    model.IsAllowedEdit = 1;
                    model.ItemName = o["ItemName"].ToString();
                    model.ItemType = "菜品分类";
                    model.ItemValue = null;
                    model.SortNo = Convert.ToDecimal(o["SortNo"]);
                    mealDictDal.InsertReturnLastId(model, x => x.ItemID);
                }
                else if (state == "removed" || state == "deleted")
                {
                    //employeeDal.Delete(id);
                }
                else if (state == "modified" || state == "") //更新：_state为空或modified
                {
                    //employeeDal.Update(o);
                }

                //if (i == 2) throw new Exception("aaa");

            }

            var result = new {};
            return Json(result);
        }
    }
}

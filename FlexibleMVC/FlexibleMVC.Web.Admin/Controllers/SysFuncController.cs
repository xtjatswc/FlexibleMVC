using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.Model.Admin.Permissions;

namespace FlexibleMVC.Web.Admin.Controllers
{
    public class SysFuncController : LessBaseController
    {
        public SysFuncController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFuncList()
        {
            //查询条件
            string funcName = Request.GetSqlParamer("FuncName");
            string sysMenuID = Request.GetString("SysMenuID");
            //分页
            int pageIndex = Request.GetInt("pageIndex") + 1;
            int pageSize = Request.GetInt("pageSize");
            //字段排序
            String sortField = Request.GetString("sortField");
            String sortOrder = Request.GetString("sortOrder");

            string sWhere = "SysMenuID='" + sysMenuID + "' and FuncName like '%" + funcName + "%'";

            var sysFuncDal = flexibleContext.GetService<SysFuncDal>();
            var models = sysFuncDal.GetModels(where: sWhere, orderBy: "SortNo asc", currentPage: pageIndex, itemsPerPage: pageSize);
            var count = sysFuncDal.GetCount(where: sWhere);

            var result = new { total = count, data = models };
            return Json(result);
        }

        public JsonResult SaveFunc()
        {
            var data = Request.GetArrayList("data");
            String siteID = Request["SiteID"].ToString();
            String sysMenuID = Request.GetString("SysMenuID");

            var sysFuncDal = flexibleContext.GetService<SysFuncDal>();

            for (int i = 0, l = data.Count; i < l; i++)
            {
                Hashtable o = (Hashtable)data[i];

                String id = o.GetString("ID");
                //根据记录状态，进行不同的增加、删除、修改操作
                String state = o.GetString("_state");
                String funcName = o["FuncName"].ToString();
                String funcDescribe = o.GetString("FuncDescribe");
                decimal sortNo = Convert.ToDecimal(o["SortNo"]);

                if (state == "added" || id == "")           //新增：id为空，或_state为added
                {
                    SysFunc model = new SysFunc();
                    model.ID = "{" + Guid.NewGuid() + "}";
                    model.WebSiteID = siteID;
                    model.SysMenuID = sysMenuID;
                    model.FuncName = funcName;
                    model.FuncDescribe = funcDescribe;
                    model.SortNo = sortNo;
                    sysFuncDal.Insert(model);
                }
                else if (state == "removed" || state == "deleted")
                {
                    sysFuncDal.Delete(id);
                }
                else if (state == "modified" || state == "") //更新：_state为空或modified
                {
                    var model = sysFuncDal.GetModel(id);
                    model.WebSiteID = siteID;
                    model.SysMenuID = sysMenuID;
                    model.FuncName = funcName;
                    model.FuncDescribe = funcDescribe;
                    model.SortNo = sortNo;
                    sysFuncDal.Update(model, x => x.ID);
                }

            }

            var result = new { };
            return Json(result);
        }

    }
}
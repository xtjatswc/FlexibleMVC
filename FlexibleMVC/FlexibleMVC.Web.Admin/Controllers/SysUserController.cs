using System;
using System.Collections;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.Model.Admin.Permissions;
using FlexibleMVC.Model.Component;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Admin.Controllers
{
    public class SysUserController : LessBaseController
    {
        public SysUserController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetListJson(DataTablesParameters query)
        {
            string UserName = Request.GetSqlParamer("UserName");
            string LoginName = Request.GetSqlParamer("LoginName"); 

            string sWhere = " 1=1 ";
            if (!string.IsNullOrWhiteSpace(UserName))
                sWhere += $" and UserName like '{UserName}%'";

            if (!string.IsNullOrWhiteSpace(LoginName))
                sWhere += $" and LoginName like '{LoginName}%'";

            SysUserDal sysUserDal = flexibleContext.GetService<SysUserDal>();
            var list = sysUserDal.GetModels(
                where: sWhere,
                orderBy: query.OrderBy,
                currentPage: query.Start / 10 + 1,
                itemsPerPage: query.Length
                );

            int recordsCount = sysUserDal.GetCount(sWhere);

            var resultJson = new DataTablesResult<SysUser>(query.Draw, recordsCount, recordsCount, list);
            return Json(resultJson);
        }

        public JsonResult GetUserList()
        {
            //查询条件
            string key = Request.GetSqlParamer("key");
            //分页
            int pageIndex = Request.GetInt("pageIndex") + 1;
            int pageSize = Request.GetInt("pageSize");

            string sWhere = "IsDeleted = 0 and UserName like '%" + key + "%'";

            var sysUserDal = flexibleContext.GetService<SysUserDal>();
            var models = sysUserDal.GetModels(where: sWhere, orderBy: "SortNo asc", currentPage: pageIndex, itemsPerPage: pageSize);
            var count = sysUserDal.GetCount(where: sWhere);

            var result = new { total = count, data = models };
            return Json(result);
        }

        public JsonResult SaveUser()
        {
            var data = Request.GetArrayList("data");
            var sysUserDal = flexibleContext.GetService<SysUserDal>();
            string siteID = Request.GetSqlParamer("SiteID");

            for (int i = 0, l = data.Count; i < l; i++)
            {
                Hashtable o = (Hashtable)data[i];

                String id = o["ID"] != null ? o["ID"].ToString() : "";
                //根据记录状态，进行不同的增加、删除、修改操作
                String state = o["_state"] != null ? o["_state"].ToString() : "";
                String userName = o["UserName"].ToString();
                String loginName = o["LoginName"].ToString();
                String password = o["Password"].ToString();
                long isLocked = Convert.ToInt32(o["IsLocked"].ToString());
                decimal sortNo = Convert.ToDecimal(o["SortNo"]);

                if (state == "added" || id == "")           //新增：id为空，或_state为added
                {
                    SysUser model = new SysUser();
                    model.ID = "{" + Guid.NewGuid().ToString() + "}";
                    model.UserName = userName;
                    model.LoginName = loginName;
                    model.Password = password;
                    model.SortNo = sortNo;
                    model.IsLocked = isLocked;
                    sysUserDal.Insert(model);
                }
                else if (state == "removed" || state == "deleted")
                {
                    var model = sysUserDal.GetModel(id);
                    model.IsDeleted = 1;
                    sysUserDal.Update(model, x => x.ID);
                }
                else if (state == "modified" || state == "") //更新：_state为空或modified
                {
                    var model = sysUserDal.GetModel(id);
                    model.UserName = userName;
                    model.LoginName = loginName;
                    model.Password = password;
                    model.SortNo = sortNo;
                    model.IsLocked = isLocked;
                    sysUserDal.Update(model, x => x.ID);
                }
            }

            var result = new { };
            return Json(result);
        }

    }
}
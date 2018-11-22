using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.LessBase.Permissions.Model;
using FlexibleMVC.Model.Admin.Permissions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Admin.Controllers
{
    public class SysRoleController : LessBaseController
    {
        public SysRoleController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetRole()
        {
            return View();
        }

        public JsonResult SaveRoleRelation()
        {
            var users = Request.GetList<SysUser>("users");
            var roles = Request.GetList<SysRole>("roles");
            string siteID = Request.GetString("SiteID");

            var relationDal = flexibleContext.GetService<SysRoleRelationDal>();
            var sysUserDal = flexibleContext.GetService<SysUserDal>();

            foreach (var user in users)
            {
                relationDal.DeleteRelations(siteID, user.ID);
                StringBuilder roleNames = new StringBuilder();
                foreach (var role in roles)
                {
                    SysRoleRelation model = new SysRoleRelation();
                    model.WebSiteID = siteID;
                    model.SysUserID = user.ID;
                    model.SysRoleID = role.ID;
                    relationDal.Insert(model);

                    roleNames.Append(role.RoleName);
                    roleNames.Append(",");
                }

                SysUser u = sysUserDal.GetModel(user.ID);
                u.RoleNames = roleNames.ToString().TrimEnd(',');
                sysUserDal.Update(u, x=>x.ID);
            }

            return Json("");
        }

        public JsonResult GetRoleList()
        {
            //查询条件
            string siteID = Request.GetSqlParamer("SiteID");
            string key = Request.GetSqlParamer("key");
            //分页
            int pageIndex = Request.GetInt("pageIndex") + 1;
            int pageSize = Request.GetInt("pageSize");

            string sWhere = "WebSiteID = '" + siteID + "' and IsDeleted = 0 and RoleName like '%" + key + "%'";

            var sysRoleDal = flexibleContext.GetService<SysRoleDal>();
            var models = sysRoleDal.GetModels(where: sWhere, orderBy: "SortNo asc", currentPage: pageIndex, itemsPerPage: pageSize);
            var count = sysRoleDal.GetCount(where: sWhere);

            var result = new { total = count, data = models };
            return Json(result);
        }

        public JsonResult SaveRole()
        {
            var data = Request.GetArrayList("data");
            var sysRoleDal = flexibleContext.GetService<SysRoleDal>();
            string siteID = Request.GetSqlParamer("SiteID");

            for (int i = 0, l = data.Count; i < l; i++)
            {
                Hashtable o = (Hashtable)data[i];

                String id = o["ID"] != null ? o["ID"].ToString() : "";
                //根据记录状态，进行不同的增加、删除、修改操作
                String state = o["_state"] != null ? o["_state"].ToString() : "";
                String roleName = o["RoleName"].ToString();
                decimal sortNo = Convert.ToDecimal(o["SortNo"]);

                if (state == "added" || id == "")           //新增：id为空，或_state为added
                {
                    SysRole model = new SysRole();
                    model.ID = "{" + Guid.NewGuid().ToString() + "}";
                    model.RoleName = roleName;
                    model.SortNo = sortNo;
                    model.WebSiteID = siteID;
                    sysRoleDal.Insert(model);
                }
                else if (state == "removed" || state == "deleted")
                {
                    sysRoleDal.DeleteExt(id);
                }
                else if (state == "modified" || state == "") //更新：_state为空或modified
                {
                    var model = sysRoleDal.GetModel(id);
                    model.RoleName = roleName;
                    model.SortNo = sortNo;
                    sysRoleDal.Update(model, x => x.ID);
                }
            }

            var result = new { };
            return Json(result);
        }

        public JsonResult GetRoleTree()
        {
            string siteID = Request.GetSqlParamer("SiteID");
            var sysRoleDal = flexibleContext.GetService<SysRoleDal>();
            var roleList = sysRoleDal.GetModels("WebSiteID='"+ siteID +"'");
            var tree = new List<object>
            {
                new { id = "0", text = "系统角色", pid = "" }
            };

            foreach (var model in roleList)
            {
                tree.Add(new { id = model.ID, text = model.RoleName, pid = "0"});
            }

            return Json(tree);
        }

    }
}

using System;
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
    public class SysPermissionsController : LessBaseController
    {
        public SysPermissionsController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMenuFuncTreeList()
        {
            string siteID = Request.GetSqlParamer("SiteID");
            string roleID = Request.GetSqlParamer("RoleID");

            var sysMenuDal = flexibleContext.GetService<SysMenuDal>();
            var lstMenu = sysMenuDal.GetModels(siteID);

            var sysFuncDal = flexibleContext.GetService<SysFuncDal>();
            var lstFunc = sysFuncDal.GetModels(siteID);

            var spmDal = flexibleContext.GetService<SysPermissionsMenuDal>();
            var limitMenu = spmDal.GetModels(siteID, roleID);

            var spfDal = flexibleContext.GetService<SysPermissionsFuncDal>();
            var limitFunc = spfDal.GetModels(siteID, roleID);

            //导航菜单
            var lstResult = new List<Object>();
            foreach (var menu in lstMenu)
            {
                lstResult.Add(new
                {
                    ItemID = menu.ID,
                    ItemName = menu.MenuName,
                    ParentItemID = menu.ParentID,
                    FuncDescribe = "",
                    Checked = limitMenu.Contains(menu.ID),
                    IsFunc = false
                });
            }

            //功能
            foreach (var func in lstFunc)
            {
                lstResult.Add(new
                {
                    ItemID = func.ID,
                    ItemName = func.FuncName,
                    ParentItemID = func.SysMenuID,
                    FuncDescribe = func.FuncDescribe,
                    Checked = limitFunc.Contains(func.ID),
                    IsFunc = true
                });
            }

            return Json(lstResult);
        }

        public JsonResult SavePermissions()
        {
            var data = Request.GetArrayList("data");
            string siteID = Request.GetSqlParamer("SiteID");
            string roleID = Request.GetSqlParamer("RoleID");

            using (var context = flexibleContext.db.UseTransaction(true))
            {
                var spmDal = flexibleContext.GetService<SysPermissionsMenuDal>();
                var spfDal = flexibleContext.GetService<SysPermissionsFuncDal>();

                //删除菜单权限
                spmDal.Db.Sql("delete from SysPermissionsMenu where WebSiteID = @0 and SysRoleID = @1", siteID, roleID).Execute();

                //删除功能权限
                spfDal.Db.Sql("delete from SysPermissionsFunc where PermissionsMenuID not in (select ID from SysPermissionsMenu)");

                foreach (var o in data.Where(o => o.GetBoolean("IsFunc") == false))
                {
                    //保存菜单权限
                    SysPermissionsMenu spm = new SysPermissionsMenu();
                    spm.ID = "{" + Guid.NewGuid() + "}";
                    spm.WebSiteID = siteID;
                    spm.SysRoleID = roleID;
                    spm.SysMenuID = o.GetString("ItemID");
                    spmDal.Insert(spm);

                    //保存功能权限
                    var funcs = data.Where(f =>
                        f.GetBoolean("IsFunc") && f.GetString("ParentItemID") == spm.SysMenuID);
                    foreach (var func in funcs)
                    {
                        SysPermissionsFunc spf = new SysPermissionsFunc();
                        spf.PermissionsMenuID = spm.ID;
                        spf.SysFuncID = func.GetString("ItemID");
                        spfDal.Insert(spf);
                    }
                }

                context.Commit();
            }

            var result = new { };
            return Json(result);
        }
    }
}
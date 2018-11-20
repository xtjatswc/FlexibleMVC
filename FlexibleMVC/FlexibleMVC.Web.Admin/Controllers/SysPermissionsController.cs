using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Extension;

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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlexibleMVC.BLL.Admin.Permissions;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.Model.Admin.Permissions;

namespace FlexibleMVC.Web.Admin.Controllers
{
    public class SysMenuController : LessBaseController
    {
        public SysMenuController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        public JsonResult GetLimitNav()
        {
            string siteID = Request.GetString("SiteID");

            var sysUserBll = flexibleContext.GetService<SysUserBll>();
            var sysMenuDal = flexibleContext.GetService<SysMenuDal>();

            //获取登录用户
            SysUser sysUser = sysUserBll.getCurrentUser();

            //获取有权限的菜单
            var limitMenu = sysMenuDal.GetLimitModels(siteID, sysUser.ID);

            return Json(limitMenu);

            //return Json(sysMenuDal.GetModels(siteID));
        }

        public JsonResult GetListNav()
        {
            string siteID = Request.GetString("SiteID");

            var sysMenuDal = flexibleContext.GetService<SysMenuDal>();

            return Json(sysMenuDal.GetModels(siteID));
        }


    }
}
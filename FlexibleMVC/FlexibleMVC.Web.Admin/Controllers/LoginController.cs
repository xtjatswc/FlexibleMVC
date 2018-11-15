using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using System.Web.Mvc;
using FlexibleMVC.Base.Jwt;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.BLL.Admin.Permissions;
using FlexibleMVC.Model.Admin.Permissions;

namespace FlexibleMVC.Web.Admin.Controllers
{
    [CheckUserRole(Enabled = false)]
    public class LoginController : LessBaseController
    {
        public LoginController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(string webSiteID, string loginName, string password)
        {
            SysUserBll sysUserBll = flexibleContext.GetService<SysUserBll>();
            LoginResult loginResult = sysUserBll.CheckLogin(webSiteID, loginName, password);

            //return Redirect("/frond_b_Home/index");
            return Json(loginResult);

        }

    }
}
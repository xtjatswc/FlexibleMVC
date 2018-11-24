/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */

using FlexibleMVC.Base.JsonConfig;
using FlexibleMVC.BLL.Admin.Permissions;
using FlexibleMVC.DAL;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Permissions.Model;
using FlexibleMVC.Model;
using FlexibleMVC.Model.Admin.Permissions;
using FluentData;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Web.Mvc;
using System.Xml;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Controllers
{
    public class HomeController : LessBaseController
    {
        public HomeController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        [CheckUserRole(WhenNotPassedRedirectUrl = "~/bjdc_system_login")]
        public ActionResult Index()
        {
            return View();
        }
    }
}

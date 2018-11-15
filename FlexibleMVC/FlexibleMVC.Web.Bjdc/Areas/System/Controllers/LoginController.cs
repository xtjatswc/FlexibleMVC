using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Filters.Permission;

namespace FlexibleMVC.Web.Bjdc.Areas.System.Controllers
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

    }
}
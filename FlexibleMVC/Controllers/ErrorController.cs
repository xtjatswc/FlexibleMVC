using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Filters.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Controllers
{
    [CheckUserRole(Enabled = false)]
    public class ErrorController : LessBaseController
    {
        public ErrorController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        public ActionResult CustomError()
        {
            return View();
        }

        public ActionResult Http404()
        {
            return View();
        }

        public ActionResult PermissionDenied()
        {
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Admin.Controllers
{
    public class LoginController : LessBaseController
    {
        public LoginController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckLogin()
        {
            string userName = Request.Form["UserName"];
            string password = Request.Form["Password"];

            return RedirectToAction("Index", "Home", new {module = "admin", area = "root" });
        }

    }
}
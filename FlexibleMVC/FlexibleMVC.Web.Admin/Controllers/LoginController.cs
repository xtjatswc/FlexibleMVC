using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using System.Web.Mvc;
using FlexibleMVC.Base.Jwt;
using FlexibleMVC.LessBase.Filters.Permission;

namespace FlexibleMVC.Web.Admin.Controllers
{
    [CheckUserRole(Passed = true)]
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
            string loginName = Request.Form["loginName"];
            string password = Request.Form["password"];

            var dict = new Dictionary<string, object>();
            dict["limit"] = "10101010100111";
            dict["user"] = new { loginName = "张三", Age = 25 };
            string jwt = JwtUtil.Encode(dict, 24 * 60 * 60);
            var result = new { success = true, msg = "登录成功！", token = jwt };

            //return Redirect("/frond_b_Home/index");
            return Json(result);

        }

    }
}
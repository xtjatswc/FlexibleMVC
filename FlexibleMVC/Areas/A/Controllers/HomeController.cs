/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.Base;
using FlexibleMVC.Web.Areas.A.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Areas.A.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View("~/Areas/A/Views/Home/Contact.cshtml");
        }

        public ActionResult GotoB()
        {
            return RedirectToRoute("B_default", new { controller = "Home", Action = "Index", para = 1 });
        }

        public ActionResult Part2()
        {
            return View();
        }

        public JsonResult GetJson()
        {
            dynamic obj = new ExpandoObject();
            //添加属性
            obj.name = "Li Lei";
            obj.age = 20;
            obj.color = new { color1 = "red", color2 = "green" };
            return Json(obj);
        }

        public JsonResult TestMysql()
        {
            var department = Class1.GetDBContext().Sql(@"select * from patientbasicinfo limit 30 ").QueryMany<DataTable>();
            return Json(department);
        }
    }
}

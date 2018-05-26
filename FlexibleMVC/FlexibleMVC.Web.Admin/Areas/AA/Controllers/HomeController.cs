﻿/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.BLL;
using FlexibleMVC.DAL;
using FlexibleMVC.LessBase;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model;
using FluentData;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace FlexibleMVC.Web.Admin.Areas.AA.Controllers
{
    public class HomeController : LessBaseController
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult GetModel()
        {
            IDbContext db = new DbContext().ConnectionStringName("testDBContext", new MySqlProvider());
            DataTable tbl = db.Sql(@"select * from patientbasicinfo limit 30 ").QuerySingle<DataTable>();
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn column in tbl.Columns)
            {
                sb.AppendLine("public " + column.DataType.Name + " " + column.ColumnName + "{ get; set; }<br/>");
            }
            return Content(sb.ToString());
        }

        [OutputCache(Duration = 10)]
        public JsonResult TestMysql()
        {
            return Json(NonAction());
        }

        [NonAction]
        private List<PatientBasicInfo> NonAction()
        {
            var patientBll = lessContext.Get<PatientBll>();
            var result = patientBll.dal.GetPatients();

            patientBll = lessContext.Get<PatientBll>();
            var list = patientBll.dal.GetPatients();

            var dal = lessContext.Get<PatientDal>();
            list = dal.GetPatients();

            return list;
        }

        public ActionResult Part2()
        {
            return Content("这是来自admin aa模块的part2");
        }

        public ActionResult GetOther()
        {
            var otherController = DependencyResolver.Current.GetService<FlexibleMVC.Web.Areas.B.Controllers.HomeController>();
            var result = otherController.Contact2("嘿嘿嘿");
            return result;
        }

    }
}

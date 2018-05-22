/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.Base;
using FluentData;
using System;
using System.Data;
using System.Web.Mvc;
using System.Text;
using FlexibleMVC.Web.Admin.Areas.AA.Model;
using System.Collections.Generic;

namespace FlexibleMVC.Web.Admin.Areas.AA.Controllers
{
	public class HomeController : BaseController
    {
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

        public JsonResult TestMysql()
        {
            IDbContext db = new DbContext().ConnectionStringName("testDBContext", new MySqlProvider());
            List<Department> department = db.Sql(@"select * from patientbasicinfo limit 30 ").QueryMany<Department>();
            return Json(department);
        }


    }
}

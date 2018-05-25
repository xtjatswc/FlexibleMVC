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
using FlexibleMVC.Model;
using System.Collections.Generic;
using FlexibleMVC.BLL;
using System.Web.Routing;

namespace FlexibleMVC.Web.Admin.Areas.AA.Controllers
{
    public class HomeController : BaseController
    {
        PatientBll patientBll = new PatientBll();

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            patientBll.flexibleContext = flexibleContext;
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
            return patientBll.GetPatients();
        }

        public ActionResult Part2()
        {
            return Content("这是来自admin aa模块的part2");
        }
    }
}

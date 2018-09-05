using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.Model.Admin.Permissions;
using FlexibleMVC.Model.Component;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Admin.Controllers
{
    public class SysUserController : LessBaseController
    {
        public SysUserController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetListJson(DataTablesParameters query)
        {
            string UserName = Request.GetSqlParamer("UserName");
            string LoginName = Request.GetSqlParamer("LoginName"); 

            string sWhere = " 1=1 ";
            if (!string.IsNullOrWhiteSpace(UserName))
                sWhere += $" and UserName like '{UserName}%'";

            if (!string.IsNullOrWhiteSpace(LoginName))
                sWhere += $" and LoginName like '{LoginName}%'";

            SysUserDal sysUserDal = flexibleContext.GetService<SysUserDal>();
            var list = sysUserDal.GetModels(
                where: sWhere,
                orderBy: query.OrderBy,
                currentPage: query.Start / 10 + 1,
                itemsPerPage: query.Length
                );

            int recordsCount = sysUserDal.GetCount(sWhere);

            var resultJson = new DataTablesResult<SysUser>(query.Draw, recordsCount, recordsCount, list);
            return Json(resultJson);
        }

        

    }
}
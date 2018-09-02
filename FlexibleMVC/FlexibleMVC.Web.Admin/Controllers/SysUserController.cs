using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
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

        public ActionResult GetListJson()
        {
            DataTablesParameters query = DataTablesParameters.GetParameters(Request.Form);

            string sWhere = " 1=1 ";
            foreach(var c in query.WhereEach())
            {
                switch (c.Data)
                {
                    case "UserName":
                    case "LoginName":
                        sWhere += $" and {c.Data} like '{c.Search.Value}%'";
                        break;
                }
            }

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
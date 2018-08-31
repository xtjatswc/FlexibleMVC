using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.Model.Admin.Permissions;
using FlexibleMVC.Model.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            SysUserDal sysUserDal = flexibleContext.GetService<SysUserDal>();
            var list = sysUserDal.GetModels(
                orderBy: query.OrderBy + " " + query.OrderDir,
                currentPage: query.Start / 10 + 1,
                itemsPerPage: query.Length
                );

            int recordsCount = sysUserDal.GetCount();

            var resultJson = new DataTablesResult<SysUser>(query.Draw, recordsCount, recordsCount, list);
            return Json(resultJson);
        }

    }
}
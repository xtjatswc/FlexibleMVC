using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
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

        public ActionResult GetListJson()
        {
            SysUserDal sysUserDal = flexibleContext.GetService<SysUserDal>();
            var list = sysUserDal.GetModels();
            return Json(list);
        }

    }
}
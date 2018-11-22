/*
 * 用户： zxs
 * 日期: 2018/5/18
 * 时间: 10:13
 */
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.Web.Filters;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Context;
using System.Linq;
using FlexibleMVC.LessBase.Filters.Permission;

namespace FlexibleMVC.Web.Controllers
{
    public class ErrorController : LessBaseController
    {
        public ErrorController(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        public ActionResult CustomError()
		{
            return View();
		}

       
    }
}

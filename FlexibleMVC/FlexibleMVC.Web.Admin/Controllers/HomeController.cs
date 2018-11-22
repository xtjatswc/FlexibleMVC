/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.Base.Mvc.Context;
using FlexibleMVC.Base.Mvc.Ctrller;
using FlexibleMVC.BLL.Admin.Permissions;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.LessBase.Permissions.Model;
using FlexibleMVC.Model.Admin.Permissions;
using System.Web.Mvc;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;

namespace FlexibleMVC.Web.Admin.Controllers
{
    public class HomeController : LessBaseController
    {
        public HomeController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        [CheckUserRole(WhenNotPassedRedirectUrl = "/Admin_Login/Index")]
        public ActionResult Index()
        {
            SysUserBll sysUserBll = flexibleContext.GetService<SysUserBll>();
            if (flexibleContext.CurrentUser == null)                
                return RedirectPermanent("/Admin_Login/Index");

            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public PartialViewResult Part2()
        {
            return PartialView();
        }
    }
}

/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.Base.Mvc.Context;
using FlexibleMVC.Base.Mvc.Ctrller;
using FlexibleMVC.BLL.Admin.Permissions;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.Model.Admin.Permissions;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Admin.Controllers
{
    public class HomeController : BaseController<FlexibleContext>
    {
        public HomeController(FlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        [CheckUserRole(WhenNotPassedRedirectUrl = "/Admin_Login/Index")]
        public ActionResult Index()
        {
            SysUserBll sysUserBll = flexibleContext.GetService<SysUserBll>();
            SysUser sysUser = sysUserBll.getCurrentUser();
            if (sysUser == null)                
                return RedirectPermanent("/Admin_Login/Index");

            return View(sysUser);
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

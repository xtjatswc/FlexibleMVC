/*
 * 用户： zxs
 * 日期: 2018/5/17
 * 时间: 10:45
 */
using FlexibleMVC.Base.Ctrller;
using System.Web.Mvc;
using FlexibleMVC.Base.Context;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.Model.Admin.Permissions;
using FlexibleMVC.DAL.Admin.Permissions;

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
            SysUserDal sysUserDal = flexibleContext.GetService<SysUserDal>();
            SysUser sysUser = sysUserDal.GetUserByLoginName(Jwt.Result["user"].loginName.ToString());

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

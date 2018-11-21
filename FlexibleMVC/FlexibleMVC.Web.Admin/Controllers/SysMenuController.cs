using System;
using System.Collections;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FlexibleMVC.BLL.Admin.Permissions;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.Model.Admin.Permissions;

namespace FlexibleMVC.Web.Admin.Controllers
{
    public class SysMenuController : LessBaseController
    {
        public SysMenuController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetLimitNav()
        {
            string siteID = Request.GetString("SiteID");

            var sysUserBll = flexibleContext.GetService<SysUserBll>();
            var sysMenuDal = flexibleContext.GetService<SysMenuDal>();

            //获取登录用户
            SysUser sysUser = sysUserBll.getCurrentUser();

            //获取有权限的菜单
            var limitMenu = sysMenuDal.GetLimitModels(siteID, sysUser.ID);

            return Json(limitMenu);

            //return Json(sysMenuDal.GetModels(siteID));
        }

        public JsonResult GetListNav()
        {
            string siteID = Request.GetString("SiteID");

            var sysMenuDal = flexibleContext.GetService<SysMenuDal>();

            return Json(sysMenuDal.GetModels(siteID));
        }

        public JsonResult GetChildListNav()
        {
            string parentID = Request.GetString("ParentID");
            string key = Request.GetString("key");

            var sysMenuDal = flexibleContext.GetService<SysMenuDal>();
            var model = sysMenuDal.GetChildMenu(parentID, key);

            return Json(model);
        }

        public JsonResult SaveMenu()
        {
            var data = Request.GetArrayList("data");
            string parentID = Request.GetString("ParentID");
            string siteID = Request.GetString("SiteID");

            var sysMenuDal = flexibleContext.GetService<SysMenuDal>();

            for (int i = 0, l = data.Count; i < l; i++)
            {
                Hashtable o = (Hashtable)data[i];

                String id = o.GetString("ID");
                //根据记录状态，进行不同的增加、删除、修改操作
                String state = o.GetString("_state");
                String menuName = o.GetString("MenuName");
                String navUrl = o.GetString("NavUrl");
                decimal sortNo = o.GetDecimal("SortNo");

                if (state == "added" || id == "")           //新增：id为空，或_state为added
                {
                    SysMenu model = new SysMenu();
                    model.ID = "{" + Guid.NewGuid() + "}";
                    model.MenuName = menuName;
                    model.ParentID = parentID;
                    model.NavUrl = navUrl;
                    model.WebSiteID = siteID;
                    model.SortNo = sortNo;
                    sysMenuDal.Insert(model);
                }
                else if (state == "removed" || state == "deleted")
                {
                    sysMenuDal.Delete(id);
                }
                else if (state == "modified" || state == "") //更新：_state为空或modified
                {
                    var model = sysMenuDal.GetModel(id);
                    model.MenuName = menuName;
                    model.ParentID = parentID;
                    model.NavUrl = navUrl;
                    model.WebSiteID = siteID;
                    model.SortNo = sortNo;
                    sysMenuDal.Update(model, x => x.ID);
                }
            }

            var result = new { };
            return Json(result);
        }

        public JsonResult DropMenu()
        {
            var sysMenuDal = flexibleContext.GetService<SysMenuDal>();

            string dragAction = Request.GetString("dragAction");
            SysMenu dragNode = Request.Get<SysMenu>("dragNode");
            SysMenu sourceNode = sysMenuDal.GetModel(dragNode.ID);
            SysMenu targetNode = Request.Get<SysMenu>("targetNode");


            switch (dragAction)
            {
                case "before":

                    sourceNode.SortNo = targetNode.SortNo - 0.1m;
                    sourceNode.ParentID = targetNode.ParentID;
                    sysMenuDal.Update(sourceNode, x => x.ID);
                    break;
                case "after":

                    sourceNode.SortNo = targetNode.SortNo + 0.1m;
                    sourceNode.ParentID = targetNode.ParentID;
                    sysMenuDal.Update(sourceNode, x => x.ID);
                    break;
                case "add":

                    sourceNode.ParentID = targetNode.ID;
                    sysMenuDal.Update(sourceNode, x => x.ID);
                    break;

            }

            return Json(new { });
        }

        public JsonResult CreateWbs()
        {
            string siteID = Request.GetString("SiteID");

            var sysMenuBll = flexibleContext.GetService<SysMenuBll>();
            sysMenuBll.RecursionWbs(1, "", "");

            return Json(new { });

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model.Admin.Permissions;

namespace FlexibleMVC.DAL.Admin.Permissions
{
    public class SysMenuDal : BaseDAL<SysMenu>
    {
        public SysMenuDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db1;
        }

        public List<SysMenu> GetModels(string siteID)
        {
            var models = GetModels(where: "WebSiteID='" + siteID + "'", orderBy: "SortNo asc");
            return models;
        }

        /// <summary>
        /// 获取站点下某个用户有权限的所有菜单
        /// </summary>
        /// <param name="siteID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<dynamic> GetLimitModels(string siteID, string userID)
        {
            var limitMenu = Db.Sql(@"select DISTINCT e.*,d.ID PermissionsMenuID from SysUser a 
            INNER JOIN SysRoleRelation b on a.ID = b.SysUserID
            INNER join SysRole c on c.ID = b.SysRoleID and c.WebSiteID = @WebSiteID
            INNER JOIN SysPermissionsMenu d on d.SysRoleID = c.ID and d.WebSiteID = @WebSiteID
            INNER join SysMenu e on e.ID = d.SysMenuID
            where a.ID = @SysUserID order by e.SortNo")
                .Parameter("WebSiteID", siteID)
                .Parameter("SysUserID", userID)
                .QueryMany<dynamic>();
            return limitMenu;
        }

        public List<SysMenu> GetChildMenu(string siteID, string parentID, string keyword = "")
        {
            var model = GetModels(where: "WebSiteID='" + siteID + "' and ParentID='" + parentID + "' and MenuName like '%" + keyword + "%'", orderBy: "SortNo asc");
            return model;
        }
    }
}

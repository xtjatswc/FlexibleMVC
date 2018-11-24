using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model.Admin.Permissions;
using FluentData;

namespace FlexibleMVC.DAL.Admin.Permissions
{
    public class SysPermissionsMenuDal : BaseDAL<SysPermissionsMenu>
    {
        public SysPermissionsMenuDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db1;
        }

        public SortedSet<string> GetModels(string siteID, string roleID)
        {
            var models = Db.Sql("select SysMenuID from SysPermissionsMenu where WebSiteID=@WebSiteID and SysRoleID=@SysRoleID")
                             .Parameter("WebSiteID", siteID)
                             .Parameter("SysRoleID", roleID)
                             .QueryMany<string>().ToSortedSet();

            return models;
        }

        public void DeletePermissionsMenu(string siteID, string roleID)
        {
            Db.Sql("delete from SysPermissionsMenu where WebSiteID = @0 and SysRoleID = @1", siteID, roleID).Execute();
            Db.Sql("delete from SysPermissionsMenu where SysMenuID not in (select ID from SysMenu)").Execute();
        }
    }
}

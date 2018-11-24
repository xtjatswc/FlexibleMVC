using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model.Admin.Permissions;

namespace FlexibleMVC.DAL.Admin.Permissions
{
    public class SysPermissionsFuncDal : BaseDAL<SysPermissionsFunc>
    {
        public SysPermissionsFuncDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db1;
        }

        public SortedSet<string> GetModels(string siteID, string roleID)
        {
            var models = Db
                .Sql(@"select b.SysFuncID from SysPermissionsMenu a 
            inner join SysPermissionsFunc b on a.ID = b.PermissionsMenuID
            where a.WebSiteID = @WebSiteID and a.SysRoleID = @SysRoleID")
                .Parameter("WebSiteID", siteID)
                .Parameter("SysRoleID", roleID)
                .QueryMany<string>().ToSortedSet();

            return models;
        }

        public void DeletePermissionsFunc()
        {
            Db.Sql("delete from SysPermissionsFunc where PermissionsMenuID not in (select ID from SysPermissionsMenu)").Execute();
            Db.Sql("delete from SysPermissionsFunc where SysFuncID not in (select ID from SysFunc)").Execute();
            Db.Sql("delete from SysFunc where SysMenuID not in (select ID from SysMenu)").Execute();
        }

    }
}

using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model.Admin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.DAL.Admin.Permissions
{
    public class SysRoleRelationDal : BaseDAL<SysRoleRelation>
    {
        public SysRoleRelationDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db1;
        }

        public int DeleteRelations(string SiteID, string userID)
        {
            return Db.Sql("delete from SysRoleRelation where WebSiteID = @WebSiteID and SysUserID = @SysUserID")
                .Parameter("WebSiteID", SiteID)
                .Parameter("SysUserID", userID).Execute();
        }
    }
}

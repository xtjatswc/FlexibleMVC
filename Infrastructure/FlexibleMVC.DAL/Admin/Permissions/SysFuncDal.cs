using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model.Admin.Permissions;

namespace FlexibleMVC.DAL.Admin.Permissions
{
    public class SysFuncDal : BaseDAL<SysFunc>
    {
        public SysFuncDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db1;
        }

        //获取权限菜单下所有有权限的功能
        public List<dynamic> GetLimitModels(string permissionsMenuID)
        {
            var limitFunc = Db.Sql(@"select DISTINCT b.FuncName, c.SysFuncID from SysPermissionsMenu a
INNER JOIN SysFunc b on b.SysMenuID = a.SysMenuID
left join SysPermissionsFunc c on c.SysFuncID = b.ID
where a.ID = @permissionsMenuID")
                .Parameter("permissionsMenuID", permissionsMenuID)
                .QueryMany<dynamic>();
            return limitFunc;
        }

    }
}

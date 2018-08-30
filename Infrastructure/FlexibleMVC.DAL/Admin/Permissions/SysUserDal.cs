using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model.Admin.Permissions;
using FluentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.DAL.Admin.Permissions
{
    public class SysUserDal : BaseDAL<SysUser>
    {
        public SysUserDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db1;
        }

        public SysUser GetUserByLoginName(string loginName)
        {
            var model = Db.Sql(@"select * from " + TableName + " where IsDeleted = 0 and loginName = @0", loginName).QuerySingle<SysUser>();
            return model;
        }

    }
}

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
        }

        protected override string PrimaryKey => "ID";

        protected override string TableName => "SysUser";

        protected override IDbContext Db => lessContext.db1;
    }
}

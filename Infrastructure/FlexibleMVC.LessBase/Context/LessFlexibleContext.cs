using System.Collections.Generic;
using FlexibleMVC.Base.Mvc.Context;
using FlexibleMVC.LessBase.Config;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Permissions.Model;
using FluentData;

namespace FlexibleMVC.LessBase.Context
{
    public class LessFlexibleContext : FlexibleContext
    {
        public IDbContext db = new DbContext().ConnectionString(LessConfig.db1, new MySqlProvider());
        public IDbContext db1 = new DbContext().ConnectionString(LessConfig.db2, new SqliteProvider());

        //权限
        public Dictionary<string, bool> Limit { get; set; }

        //当前登录用户
        public SysUser CurrentUser { get; set; }

    }
}

using FlexibleMVC.Base.JsonConfig;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Infrastructure.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Model.Admin.Permissions
{
    public class LoginResult : JsonResultInfo
    {
        public string token { get; set; }
        public SysWebSite sysWebSite { get; set; }
    }

    [TableName("SysUser")]
    public class SysUser : BaseModel
    {
        public String UserName { get; set; }
        public String LoginName { get; set; }
        public String Password { get; set; }
        public Int64 IsLocked { get; set; }
        public String Mobile { get; set; }
        public String Email { get; set; }
        public DateTime LastLoginTime { get; set; }
        public Int64 LoginCount { get; set; }
        public String Photo { get; set; }
        public Int64 IsAdmin { get; set; }
        public decimal SortNo { get; set; }
        public String RoleNames { get; set; }
    }
}

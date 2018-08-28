using FlexibleMVC.LessBase.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Model.Admin.Permissions
{
    public class SysUser : BaseModel
    {
        public String ID { get; set; }
        public String UserName { get; set; }
        public String LoginName { get; set; }
        public String Password { get; set; }
        public Int64 IsLocked { get; set; }
        public String Mobile { get; set; }
        public String Email { get; set; }
        public Int64 LastLoginTime { get; set; }
        public Int64 LoginCount { get; set; }
        public Int64 IsDeleted { get; set; }
        public String Photo { get; set; }
        public Int64 IsAdmin { get; set; }
    }
}

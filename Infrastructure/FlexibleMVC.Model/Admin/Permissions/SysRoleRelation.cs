using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Model.Admin.Permissions
{
    public class SysRoleRelation
    {
        public String WebSiteID { get; set; }
        public String SysUserID { get; set; }
        public String SysRoleID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.LessBase.Infrastructure;

namespace FlexibleMVC.Model.Admin.Permissions
{
    public class SysPermissionsMenu
    {
        public String ID { get; set; }
        public String WebSiteID { get; set; }
        public String SysRoleID { get; set; }
        public String SysMenuID { get; set; }
    }
}

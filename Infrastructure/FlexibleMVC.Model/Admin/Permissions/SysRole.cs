using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.LessBase.Infrastructure;

namespace FlexibleMVC.Model.Admin.Permissions
{
    public class SysRole : BaseModel
    {
        public String WebSiteID { get; set; }
        public String RoleName { get; set; }
        public decimal SortNo { get; set; }

    }
}

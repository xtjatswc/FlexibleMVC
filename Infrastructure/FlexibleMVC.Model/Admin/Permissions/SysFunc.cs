using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.LessBase.Infrastructure;

namespace FlexibleMVC.Model.Admin.Permissions
{
    public class SysFunc : BaseModel
    {
        public String WebSiteID { get; set; }
        public String SysMenuID { get; set; }
        public String FuncName { get; set; }
        public String FuncDescribe { get; set; }
        public decimal SortNo { get; set; }
    }
}

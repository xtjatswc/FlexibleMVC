using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Infrastructure.Attribute;

namespace FlexibleMVC.Model.Admin.Permissions
{
    [TableName("SysMenu")]
    public class SysMenu : BaseModel
    {
        public String WebSiteID { get; set; }
        public String MenuName { get; set; }
        public String ParentID { get; set; }
        public String NavUrl { get; set; }
        public decimal SortNo { get; set; }
    }
}

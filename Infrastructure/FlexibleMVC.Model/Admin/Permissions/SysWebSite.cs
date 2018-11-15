using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Infrastructure.Attribute;

namespace FlexibleMVC.Model.Admin.Permissions
{
    [TableName("SysWebSite")]
    public class SysWebSite : BaseModel
    {
        public String SiteName { get; set; }
        public String LoginUrl { get; set; }
        public String MainUrl { get; set; }
    }
}

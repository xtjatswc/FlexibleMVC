using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Infrastructure.Attribute;

namespace FlexibleMVC.LessBase.Permissions.Model
{
    [TableName("SysWebSite")]
    public class SysWebSite : BaseModel
    {
        public String SiteName { get; set; }
        public String Copyright { get; set; }
        public String LoginUrl { get; set; }
        public String MainUrl { get; set; }
    }
}

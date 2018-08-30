using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.Base.JsonConfig;
using FlexibleMVC.LessBase.Infrastructure.Attribute;
using Newtonsoft.Json;

namespace FlexibleMVC.LessBase.Infrastructure
{
    public class BaseModel
    {
        [PrimaryKey()]
        public string ID { get; set; }
        public Int64 IsDeleted { get; set; }

        public string ToJson()
        {
            if (this == null)
                return "";
            return JsonUtil.ToJson(this);
        }
    }
}

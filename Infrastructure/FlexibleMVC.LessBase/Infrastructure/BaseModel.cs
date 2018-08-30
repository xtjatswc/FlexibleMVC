using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace FlexibleMVC.LessBase.Infrastructure
{
    public class BaseModel
    {
        public String ID { get; set; }

        public string ToJson()
        {
            if (this == null)
                return "";
            return JsonConvert.SerializeObject(this);
        }
    }
}

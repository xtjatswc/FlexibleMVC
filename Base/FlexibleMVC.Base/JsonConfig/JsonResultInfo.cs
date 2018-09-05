using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Base.JsonConfig
{
    public class JsonResultInfo
    {
        public bool Success { get; set; } = false;
        public string Msg { get; set; }
        public bool Timeout { get; set; } = false;
    }
}

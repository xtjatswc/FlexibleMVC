using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Model.Admin.Permissions
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Msg { get; set; }
        public string Token { get; set; }
    }
}

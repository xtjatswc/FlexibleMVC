using FlexibleMVC.Base.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Base.Ctrller
{
    public interface IBaseController
    {
        JwtResult Jwt { get; set; }
    }
}

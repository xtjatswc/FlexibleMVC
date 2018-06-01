using FlexibleMVC.LessBase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.LessBase.Infrastructure
{
    public interface IBaseDAL
    {
        LessFlexibleContext lessContext { get; set; }
    }
}

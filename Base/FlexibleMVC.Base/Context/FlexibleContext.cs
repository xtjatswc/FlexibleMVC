using FluentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FlexibleMVC.Base.Context
{
    public class FlexibleContext
    {
        public log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public virtual TService Get<TService>()
        {
            var T = DependencyResolver.Current.GetService<TService>();
            return T;
        }
    }
}

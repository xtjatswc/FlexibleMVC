using FlexibleMVC.Base.Jwt;
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
        public JwtResult Jwt { get => DependencyResolver.Current.GetService<JwtResult>(); }

        public log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public virtual TService GetService<TService>()
        {
            return DependencyResolver.Current.GetService<TService>();
        }

        public virtual IEnumerable<TService> GetServices<TService>()
        {
            return DependencyResolver.Current.GetServices<TService>();
        }

    }
}

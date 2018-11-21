using FlexibleMVC.Base.Jwt;
using FluentData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FlexibleMVC.Base.Mvc.Context
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

        public string AppPath { get; set; }
        public dynamic Model { get; set; } = new ExpandoObject();
        public Hashtable Items { get; set; } = new Hashtable();
    }
}

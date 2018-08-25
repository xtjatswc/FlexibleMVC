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

        protected Dictionary<Type, object> objCache = new Dictionary<Type, object>();
        public virtual TService Get<TService>()
        {
            Type cacheKey = typeof(TService);
            if (objCache.ContainsKey(cacheKey))
            {
                return (TService)objCache[cacheKey];
            }

            var T = DependencyResolver.Current.GetService<TService>();
            objCache[cacheKey] = T;

            return T;
        }
    }
}

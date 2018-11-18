using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Properties;

namespace FlexibleMVC.Base.Mvc.TempDataProvider
{

    /// <summary>
    /// 重写Mvc的TempData存取规则
    /// SessionStateTempDataProvider是用Session存储，如果碰到应用程序禁用Session，或者跨域的情况，就会出问题
    /// 重写之后，是用HttpContext.Cache存储，这样跨域也是没问题的，唯一的问题可能就是全局共享的，没法区分Session
    /// </summary>
    public class CacheTempDataProvider : ITempDataProvider
    {
        internal const string TempDataCacheStateKey = "__ControllerTempData";

        public virtual IDictionary<string, object> LoadTempData(ControllerContext controllerContext)
        {
            var cache = controllerContext.HttpContext.Cache;
            if (cache != null)
            {
                Dictionary<string, object> dictionary = cache[TempDataCacheStateKey] as Dictionary<string, object>;
                if (dictionary != null)
                {
                    cache.Remove(TempDataCacheStateKey);
                    return dictionary;
                }
            }
            return new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        public virtual void SaveTempData(ControllerContext controllerContext, IDictionary<string, object> values)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            var cache = controllerContext.HttpContext.Cache;
            bool flag = (values != null) && (values.Count > 0);
            if (cache == null)
            {
                if (flag)
                {
                    throw new InvalidOperationException("controllerContext.HttpContext.Cache SaveTempData Fail!");
                }
            }
            else if (flag)
            {
                cache[TempDataCacheStateKey] = values;
            }
            else if (cache[TempDataCacheStateKey] != null)
            {
                cache.Remove(TempDataCacheStateKey);
            }
        }
    }
}
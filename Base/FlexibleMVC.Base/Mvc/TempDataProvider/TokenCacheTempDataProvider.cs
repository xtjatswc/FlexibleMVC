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
    /// 重写之后，是用HttpContext.Cache存储，因为cache是全局的，需要做到区分Session，只能用jwt token的第三段数据做为StateKey
    /// </summary>
    public class TokenCacheTempDataProvider : ITempDataProvider
    {
        private string StateKey = "";

        private string GetStateKey(ControllerContext controllerContext)
        {
            if(StateKey == "")
            {
                string key = "";
                try
                {
                    string token = controllerContext.HttpContext.Request["token"];
                    key = "_" + token.Split('.')[2];
                }
                catch (Exception)
                {
                }

                StateKey = "__ControllerTempData" + key;
            }

            return StateKey;
        }

        public virtual IDictionary<string, object> LoadTempData(ControllerContext controllerContext)
        {
            string TempDataCacheStateKey = GetStateKey(controllerContext);
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

            string TempDataCacheStateKey = GetStateKey(controllerContext);

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
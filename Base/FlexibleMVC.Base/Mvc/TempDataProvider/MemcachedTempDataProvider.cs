using FlexibleMVC.Base.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using static FlexibleMVC.Base.JsonConfig.Config;

namespace FlexibleMVC.Base.Mvc.TempDataProvider
{
    public class MemcachedTempDataProvider : ITempDataProvider
    {

        private string StateKey = "";

        /// <summary>
        /// 缓存过期时间，单位：分钟
        /// </summary>
        private int ExpiryTime
        {
            get
            {
                return Convert.ToInt32(Global.LessBase.MemcachedTempData.ExpiryTime);
            }
        }

        private string GetStateKey(ControllerContext controllerContext)
        {
            if (StateKey == "")
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

            Dictionary<string, object> dictionary = MemCaheHelper.Get(TempDataCacheStateKey) as Dictionary<string, object>;
            if (dictionary != null)
            {
                MemCaheHelper.Set(TempDataCacheStateKey, dictionary, DateTime.MinValue);
                return dictionary;
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

            bool flag = values != null && values.Count > 0;
            if (flag)
            {
                MemCaheHelper.Set(TempDataCacheStateKey, values, DateTime.Now.AddMinutes(ExpiryTime));
                return;
            }

            if (MemCaheHelper.Get(TempDataCacheStateKey) != null)
            {
                MemCaheHelper.Set(TempDataCacheStateKey, values, DateTime.MinValue);
            }


        }
    }
}
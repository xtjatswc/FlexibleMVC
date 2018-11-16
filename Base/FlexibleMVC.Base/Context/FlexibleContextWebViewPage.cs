using FlexibleMVC.Base.Ctrller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.Base.JsonConfig;

namespace FlexibleMVC.Base.Context
{
    public class FlexibleContextWebViewPage<TModel, TContext> : System.Web.Mvc.WebViewPage<TModel>
    {

        public TContext flexibleContext;

        public override void Execute()
        {
            
        }

        public override void InitHelpers()
        {
            base.InitHelpers();
            BaseController<TContext> baseController = ((this.ViewContext.Controller) as BaseController<TContext>);
            if (baseController != null)
            {
                flexibleContext = baseController.flexibleContext;
            }

        }

        #region 获取请求参数
        public String GetString(String name)
        {
            return Request[name];
        }

        public int GetInt(String name)
        {
            return Convert.ToInt32(GetString(name));
        }

        public bool GetBoolean(String name)
        {
            return Convert.ToBoolean(GetString(name));
        }

        public DateTime GetDateTime(String name)
        {
            return Convert.ToDateTime(GetString(name));
        }

        public dynamic GetObject(String name)
        {
            return JsonUtil.ToObj<dynamic>(GetString(name));
        }

        public Hashtable GetHashtable(String name)
        {
            return JsonUtil.ToObj<Hashtable>(GetString(name));
        }

        public List<Hashtable> GetArrayList(String name)
        {
            return JsonUtil.ToObj<List<Hashtable>>(GetString(name));
        }

        #endregion


    }
}

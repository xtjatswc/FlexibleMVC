using System;
using System.Collections;
using System.Collections.Generic;
using FlexibleMVC.Base.Ctrller;
using FlexibleMVC.Base.JsonConfig;
using FlexibleMVC.LessBase.Context;

namespace FlexibleMVC.LessBase.Ctrller
{
    public class LessBaseController : BaseController<LessFlexibleContext>
    {
        public LessBaseController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
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

        public Object GetObject(String name)
        {
            return JsonUtil.ToObj<Object>(GetString(name));
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

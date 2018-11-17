using FlexibleMVC.Base.JsonConfig;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FlexibleMVC.LessBase.Extension
{
    public static class HttpRequestExtension
    {
        public static string GetSqlParamer(this HttpRequestBase request, string key)
        {
            if(request[key] != null)
                return request[key].Replace("'", "''");

            return null;
        }

        #region 获取请求参数
        public static String GetString(this HttpRequestBase request, String name)
        {
            return request[name];
        }

        public static int GetInt(this HttpRequestBase request, String name)
        {
            return Convert.ToInt32(request[name]);
        }

        public static bool GetBoolean(this HttpRequestBase request, String name)
        {
            return Convert.ToBoolean(request[name]);
        }

        public static DateTime GetDateTime(this HttpRequestBase request, String name)
        {
            return Convert.ToDateTime(request[name]);
        }

        public static Decimal GetDecimal(this HttpRequestBase request, String name)
        {
            return Convert.ToDecimal(request[name]);
        }

        public static dynamic GetObject(this HttpRequestBase request, String name)
        {
            return JsonUtil.ToObj<dynamic>(GetString(request, name));
        }

        public static Hashtable GetHashtable(this HttpRequestBase request, String name)
        {
            return JsonUtil.ToObj<Hashtable>(GetString(request, name));
        }

        public static List<Hashtable> GetArrayList(this HttpRequestBase request, String name)
        {
            return JsonUtil.ToObj<List<Hashtable>>(GetString(request, name));
        }

        #endregion

    }
}

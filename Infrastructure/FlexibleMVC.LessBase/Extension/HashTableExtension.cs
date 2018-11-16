using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.LessBase.Extension
{
    public static class HashTableExtension
    {
        #region 获取请求参数
        public static String GetString(this Hashtable request, String name)
        {
            return Convert.ToString(request[name]);
            //return request[name] != null ? request[name].ToString() : "";
        }

        //public static int GetInt(this HttpRequestBase request, String name)
        //{
        //    return Convert.ToInt32(GetString(request, name));
        //}

        //public static bool GetBoolean(this HttpRequestBase request, String name)
        //{
        //    return Convert.ToBoolean(GetString(request, name));
        //}

        //public static DateTime GetDateTime(this HttpRequestBase request, String name)
        //{
        //    return Convert.ToDateTime(GetString(request, name));
        //}

        //public static dynamic GetObject(this HttpRequestBase request, String name)
        //{
        //    return JsonUtil.ToObj<dynamic>(GetString(request, name));
        //}

        //public static Hashtable GetHashtable(this HttpRequestBase request, String name)
        //{
        //    return JsonUtil.ToObj<Hashtable>(GetString(request, name));
        //}

        //public static List<Hashtable> GetArrayList(this HttpRequestBase request, String name)
        //{
        //    return JsonUtil.ToObj<List<Hashtable>>(GetString(request, name));
        //}

        #endregion
    }
}

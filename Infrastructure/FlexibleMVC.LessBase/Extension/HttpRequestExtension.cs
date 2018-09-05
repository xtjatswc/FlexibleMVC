using System;
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
    }
}

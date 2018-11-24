using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FlexibleMVC.LessBase.Extension
{
    public static class HttpResponseExtension
    {
        //向客户端输出超时标志
        public static void AddHeaderTimeOut(this HttpResponseBase response)
        {
            response.AddHeader("SessionStatus", "TimeOut");
        }
    }
}

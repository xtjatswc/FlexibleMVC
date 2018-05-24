using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlexibleMVC.Web.Filters
{
    public class SystemErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            //处理错误消息，将其跳转到一个页面
            string controllerName = (string)filterContext.RouteData.Values["controller"];
            string actionName = (string)filterContext.RouteData.Values["action"];
            //这里简单向C盘的test.log写入了文件
            FileStream fs = new FileStream(@"e:\test.log", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            string writeText = string.Format("controllerName:[{0}]actionName:[{1}]{2}",
                controllerName, actionName, filterContext.Exception.ToString());
            sw.WriteLine(writeText);
            sw.Flush();
            sw.Close();
            fs.Close();

            /*//这里是使用log4net来记录
            log4net.ILog log = log4net.LogManager.GetLogger("controllerName:[" + controllerName + "]actionName:[" + actionName+"]");
            log.Error(filterContext.Exception.ToString());
            */

            //錯誤友好輸出，这里重新构造了一个ActionResult
            filterContext.Result = new System.Web.Mvc.ContentResult() { Content = "系统错误，请联系管理员" };
            return;
        }
    }
}
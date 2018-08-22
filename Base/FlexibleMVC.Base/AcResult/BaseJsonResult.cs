using FlexibleMVC.Base.JsonConfig;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FlexibleMVC.Base.AcResult
{
    public class BaseJsonResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            var jsonSerizlizerSetting = new JsonSerializerSettings();
            //设置取消循环引用
            jsonSerizlizerSetting.MissingMemberHandling = MissingMemberHandling.Ignore;

            var jsonSettings = Config.Global.LessBase.JsonSettings;

            //是否驼峰小写
            if (jsonSettings.CamelLowercase)
                jsonSerizlizerSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //设置日期的格式为：yyyy-MM-dd
            jsonSerizlizerSetting.DateFormatString = jsonSettings.DateFormatString;

            //是否忽略空值
            if(jsonSettings.IgnoreNullValue)
                jsonSerizlizerSetting.NullValueHandling = NullValueHandling.Ignore;

            //是否格式化json
            Formatting formatting = Formatting.None;
            if (jsonSettings.IsJsonFormat)
                formatting = Formatting.Indented;

            var json = JsonConvert.SerializeObject(Data, formatting, jsonSerizlizerSetting);
            response.Write(json);
        }
    }
}

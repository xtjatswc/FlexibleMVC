using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Base.JsonConfig
{
    public class JsonUtil
    {
        public static string ToJson(object value)
        {
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
            if (jsonSettings.IgnoreNullValue)
                jsonSerizlizerSetting.NullValueHandling = NullValueHandling.Ignore;

            //是否格式化json
            Formatting formatting = Formatting.None;
            if (jsonSettings.IsJsonFormat)
                formatting = Formatting.Indented;

            var json = JsonConvert.SerializeObject(value, formatting, jsonSerizlizerSetting);
            return json;
        }

        public static T ToObj<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string FormatJsonString(string str)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    //Indentation = 4,
                    //IndentChar = ' '
                    Indentation = 1,
                    IndentChar = '\t'
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }

        public static string FormatJson(object obj)
        {
            if (obj != null)
            {
                JsonSerializer serializer = new JsonSerializer();
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    //Indentation = 4,
                    //IndentChar = ' '
                    Indentation = 1,
                    IndentChar = '\t'
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return "{}";
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Base.JsonConfig
{
    public class JsonUtil
    {
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

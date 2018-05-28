using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace FlexibleMVC.Base.AcResult
{
    public class BaseXmlResult : ActionResult
    {
        public string RootName { get; set; }
        private object _data;
        public object Data { get => _data; set => _data = value; }

        public override void ExecuteResult(ControllerContext context)
        {
            StringBuilder xmlJson = new StringBuilder();
            string json = JsonConvert.SerializeObject(_data);

            xmlJson.AppendLine(@"{
  '?" + RootName + @"': {
    '@version': '1.0',
    '@standalone': 'yes'
  },
  '" + RootName + @"': 
");

            xmlJson.AppendLine(json);
            xmlJson.AppendLine(@"
}");
            XmlDocument doc = null;
            try
            {
                doc = JsonConvert.DeserializeXmlNode(xmlJson.ToString());
            }
            catch
            {
                throw new Exception("当传入集合时会引发该异常，请尝试用动态类型包装参数，例如： var obj = new {xxx = list};");
            }
            var response = context.HttpContext.Response;
            response.ContentType = "text/xml";
            response.Write(doc.OuterXml);

        }
    }
}

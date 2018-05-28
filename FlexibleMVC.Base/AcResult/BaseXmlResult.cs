using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace FlexibleMVC.Base.AcResult
{
    public class BaseXmlResult : ActionResult
    {
        private object _data;
        public object Data { get => _data; set => _data = value; }

        public override void ExecuteResult(ControllerContext context)
        {
            var serializer = new XmlSerializer(_data.GetType());
            var response = context.HttpContext.Response;
            response.ContentType = "text/xml";
            serializer.Serialize(response.Output, _data);
        }
    }
}

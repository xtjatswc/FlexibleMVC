using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FlexibleMVC.Base
{
    public class BaseController : Controller
    {
        protected new JsonResult Json(object data)
        {
            return new CustomsJsonResult { Data = data, ContentType = null, ContentEncoding = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        protected new JsonResult Json(object data, string contentType)
        {
            return new CustomsJsonResult { Data = data, ContentType = contentType, ContentEncoding = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        protected new JsonResult Json(object data, JsonRequestBehavior behavior)
        {
            return new CustomsJsonResult { Data = data, ContentType = null, ContentEncoding = null, JsonRequestBehavior = behavior };
        }

        protected new JsonResult Json(object data, string contentType, JsonRequestBehavior behavior)
        {
            return new CustomsJsonResult { Data = data, ContentType = contentType, ContentEncoding = null, JsonRequestBehavior = behavior };
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return new CustomsJsonResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new CustomsJsonResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = behavior };
        }
    }
}

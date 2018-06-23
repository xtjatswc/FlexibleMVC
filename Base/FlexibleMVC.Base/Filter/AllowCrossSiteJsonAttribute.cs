using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Configuration;

namespace FlexibleMVC.Base.Filter
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        private readonly bool AllowOrigin = Convert.ToBoolean(ConfigurationManager.AppSettings["Access-Control-Allow-Origin"]);

        public AllowCrossSiteJsonAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(AllowOrigin)
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(filterContext);
        }
    }
}

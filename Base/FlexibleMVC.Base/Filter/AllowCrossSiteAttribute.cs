using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Configuration;

namespace FlexibleMVC.Base.Filter
{
    public class AllowCrossSiteAttribute : ActionFilterAttribute
    {
        private readonly bool AllowCrossSite = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowCrossSite"]);

        public AllowCrossSiteAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(AllowCrossSite)
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(filterContext);
        }
    }
}

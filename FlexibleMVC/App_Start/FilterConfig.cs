﻿using FlexibleMVC.Base.Filter;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlexibleMVC.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AllowCrossSiteAttribute());
            filters.Add(new SystemErrorAttribute());
            filters.Add(new CheckUserRoleAttribute());
        }
    }
}
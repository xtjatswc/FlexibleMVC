using FlexibleMVC.Base.Mvc.Context;
using FlexibleMVC.LessBase.Config;
using FlexibleMVC.LessBase.Filters.Permission;
using FlexibleMVC.LessBase.Permissions.Model;
using System.Collections.Generic;

namespace FlexibleMVC.LessBase.Context
{
    public class LessContextWebViewPage<TModel> : FlexibleContextWebViewPage<TModel, LessFlexibleContext>
    {
        public string AppPath => flexibleContext.AppPath;
        public SysUser SysUser => flexibleContext.CurrentUser;
        public SysWebSite WebSite => flexibleContext.WebSite;
        public string MiniUI { get; set; }
        public string AdminLTE { get; set; }
        //权限
        public SysLimit Limit => flexibleContext.Limit;

        public override void InitHelpers()
        {
            base.InitHelpers();
            MiniUI = Url.Content(LessConfig.MiniUI_Path);
            AdminLTE = Url.Content(LessConfig.AdminLTE_Path);
        }
    }
}

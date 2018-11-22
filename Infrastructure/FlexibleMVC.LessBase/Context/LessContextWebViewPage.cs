using FlexibleMVC.Base.Mvc.Context;
using FlexibleMVC.LessBase.Config;
using FlexibleMVC.LessBase.Permissions.Model;
using System.Collections.Generic;

namespace FlexibleMVC.LessBase.Context
{
    public class LessContextWebViewPage<TModel> : FlexibleContextWebViewPage<TModel, LessFlexibleContext>
    {
        public string AppPath => flexibleContext.AppPath;
        public SysUser SysUser => flexibleContext.CurrentUser;
        public string MiniUI { get; set; }
        public string AdminLTE { get; set; }
        //权限
        public Dictionary<string, bool> Limit => flexibleContext.Limit;

        public override void InitHelpers()
        {
            base.InitHelpers();
            MiniUI = Url.Content(LessConfig.MiniUI_Path);
            AdminLTE = Url.Content(LessConfig.AdminLTE_Path);
        }
    }
}

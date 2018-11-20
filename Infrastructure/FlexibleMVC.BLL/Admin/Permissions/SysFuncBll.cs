using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Web;
using FlexibleMVC.Base.JsonConfig;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.LessBase.Infrastructure;

namespace FlexibleMVC.BLL.Admin.Permissions
{
    public class SysFuncBll : BaseBLL
    {
        public SysFuncDal sysFuncDal { get; set; }

        public Dictionary<string, bool> GetLimitModels(HttpRequestBase Request)
        {
            string permissionsMenuID = Request.GetString("PermissionsMenuID");
            var limitFunc = sysFuncDal.GetLimitModels(permissionsMenuID);

            var dict = new Dictionary<string, bool>();
            foreach (var limit in limitFunc)
            {
                dict.Add(limit.FuncName, limit.SysFuncID == null);
            }

            //string json = JsonUtil.ToJson(dict);
            //return JsonUtil.ToObj<dynamic>(json);

            return dict;
        }

    }
}

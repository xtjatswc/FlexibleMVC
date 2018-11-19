using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.Base.JsonConfig;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Infrastructure;

namespace FlexibleMVC.BLL.Admin.Permissions
{
    public class SysFuncBll : BaseBLL
    {
        public SysFuncDal sysFuncDal { get; set; }

        public dynamic GetLimitModels(string permissionsMenuID)
        {
            var limitFunc = sysFuncDal.GetLimitModels(permissionsMenuID);

            Dictionary<string, bool> dict = new Dictionary<string, bool>();
            foreach (var limit in limitFunc)
            {
                dict.Add(limit.FuncName, limit.SysFuncID == null);
            }

            string json = JsonUtil.ToJson(dict);

            return JsonUtil.ToObj<dynamic>(json);
        }

    }
}

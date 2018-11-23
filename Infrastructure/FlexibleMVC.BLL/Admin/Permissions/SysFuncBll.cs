using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Web;
using FlexibleMVC.Base.JsonConfig;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Extension;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Filters.Permission;

namespace FlexibleMVC.BLL.Admin.Permissions
{
    public class SysFuncBll : BaseBLL, IPermissions
    {
        public SysFuncDal sysFuncDal { get; set; }

        public SysLimit GetPermissions(LessFlexibleContext flexibleContext, HttpRequestBase Request)
        {
            string permissionsMenuID = Request.GetString("PermissionsMenuID");
            if (permissionsMenuID == null)
                return new SysLimit();

            sysFuncDal = flexibleContext.GetService<SysFuncDal>();
            var limitFunc = sysFuncDal.GetLimitModels(permissionsMenuID);

            var dict = new SysLimit { flexibleContext = flexibleContext };
            foreach (var limit in limitFunc)
            {
                dict[limit.FuncName] = (limit.SysFuncID != null);
            }

            //string json = JsonUtil.ToJson(dict);
            //return JsonUtil.ToObj<dynamic>(json);

            return dict;
        }
    }
}

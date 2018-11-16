using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model.Admin.Permissions;

namespace FlexibleMVC.DAL.Admin.Permissions
{
    public class SysMenuDal : BaseDAL<SysMenu>
    {
        public SysMenuDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db1;
        }

        public List<SysMenu> GetModels(string siteID)
        {
            var models = GetModels(where: "WebSiteID='" + siteID + "'");
            return models;
        }
    }
}

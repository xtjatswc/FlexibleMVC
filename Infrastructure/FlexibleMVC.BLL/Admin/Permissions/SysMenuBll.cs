using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Infrastructure;

namespace FlexibleMVC.BLL.Admin.Permissions
{
    public class SysMenuBll : BaseBLL
    {
        public SysMenuDal sysMenuDal { get; set; }

        public void RecursionWbs(string siteID, int level, string parentID, string parentWbs)
        {
            var rootNodes = sysMenuDal.GetChildMenu(siteID, parentID);
            for (int i = 0; i < rootNodes.Count(); i++)
            {
                var node = rootNodes[i];
                node.Wbs = parentWbs + (i + 1).ToString().PadLeft(3, '0');
                node.Level = level;
                node.SortNo = i;
                sysMenuDal.Update(node, x => x.ID);
                RecursionWbs(siteID, level + 1, node.ID, node.Wbs);
            }
        }

    }
}

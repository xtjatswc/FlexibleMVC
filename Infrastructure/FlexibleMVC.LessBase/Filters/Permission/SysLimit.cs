using FlexibleMVC.LessBase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.LessBase.Filters.Permission
{
    public class SysLimit
    {
        public LessFlexibleContext flexibleContext { get; set; }
        private Dictionary<string, bool> _limit = new Dictionary<string, bool>();

        public bool this[string key]
        {
            get
            {
                if (_limit.ContainsKey(key))
                {
                    return _limit[key];
                }
                else
                {
                    throw new PermissionDeniedException("权限请求失败！") { RedictUrl = flexibleContext.AppPath + flexibleContext.WebSite.LoginUrl};
                }
            }
            set
            {
                if (_limit.ContainsKey(key))
                {
                    _limit[key] = value;
                }
                else
                {
                    _limit.Add(key, value);
                }
            }
        }
    }

    public class PermissionDeniedException : Exception
    {
        public string RedictUrl { get; set; }

        public PermissionDeniedException(string message) : base(message)
        {

        }
    }
}

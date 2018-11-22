using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Permissions.Model;

namespace FlexibleMVC.DAL.Admin.Permissions
{
    public class SysWebSiteDal : BaseDAL<SysWebSite>
    {
        public SysWebSiteDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db1;
        }

    }
}

using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Permissions.Model;

namespace FlexibleMVC.LessBase.Permissions.DAL
{
    public class SysWebSiteDal : BaseDAL<SysWebSite>
    {
        public SysWebSiteDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db1;
        }

    }
}

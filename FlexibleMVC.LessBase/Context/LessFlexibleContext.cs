using FlexibleMVC.Base.Context;
using FlexibleMVC.LessBase.Infrastructure;
using FluentData;

namespace FlexibleMVC.LessBase.Context
{
    public class LessFlexibleContext : FlexibleContext
    {
        public IDbContext db = new DbContext().ConnectionStringName("testDBContext", new MySqlProvider());

        public override TService Get<TService>()
        {
            return base.Get<TService>();
        }
    }
}

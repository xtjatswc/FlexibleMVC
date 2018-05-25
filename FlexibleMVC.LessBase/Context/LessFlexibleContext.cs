using FlexibleMVC.Base.Context;
using FluentData;

namespace FlexibleMVC.LessBase.Context
{
    public class LessFlexibleContext : FlexibleContext
    {
        public FlexibleContext Base { get; set; }

        public IDbContext db = new DbContext().ConnectionStringName("testDBContext", new MySqlProvider());

    }
}

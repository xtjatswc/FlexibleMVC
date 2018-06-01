using FlexibleMVC.Base.Context;
using FlexibleMVC.LessBase.Infrastructure;
using FluentData;

namespace FlexibleMVC.LessBase.Context
{
    public class LessFlexibleContext : FlexibleContext
    {
        public FlexibleContext Base { get; set; }

        public IDbContext db = new DbContext().ConnectionStringName("testDBContext", new MySqlProvider());

        public override TService Get<TService>()
        {
            return base.Get<TService>();
        }

        protected override void OtherWise(object obj)
        {
            base.OtherWise(obj);

            if (obj is BaseBLL baseBll) baseBll.lessContext = this;
            else if (obj is IBaseDAL baseDal) baseDal.lessContext = this;

        }
    }
}

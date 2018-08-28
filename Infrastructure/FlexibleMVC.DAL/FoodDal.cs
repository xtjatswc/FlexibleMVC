using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model;
using FluentData;

namespace FlexibleMVC.DAL
{
    public class FoodDal : BaseDAL<ChinaFoodComposition>
    {
        public FoodDal(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        protected override string TableName { get => "chinafoodcomposition"; }

        protected override string PrimaryKey { get => "ChinaFoodComposition_DBKey"; }

        protected override IDbContext Db => lessContext.db;
    }
}

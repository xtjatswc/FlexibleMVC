using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model;

namespace FlexibleMVC.DAL
{
    public class FoodDal : BaseDAL<ChinaFoodComposition>
    {
        protected override string TableName { get => "chinafoodcomposition"; }

        protected override string PrimaryKey { get => "ChinaFoodComposition_DBKey"; }
        
    }
}

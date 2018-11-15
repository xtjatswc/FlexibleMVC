using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Web.Bjdc.Areas.System.Model;

namespace FlexibleMVC.Web.Bjdc.Areas.System.DAL
{
    public class MealDictDal : BaseDAL<MealDict>
    {
        public MealDictDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db;
        }

        public List<MealDict> GetModels(DictItemType itemType)
        {
            var models = GetModels(where: "ItemType='"+ Enum.GetName(typeof(DictItemType), itemType) + "'", orderBy: "sortNo asc");
            return models; 
        }

    }
}
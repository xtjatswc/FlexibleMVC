using FlexibleMVC.LessBase.Context;
using System.Collections.Generic;

namespace FlexibleMVC.LessBase.Infrastructure
{
    public abstract class BaseDAL<Model> : IBaseDAL
    {
        public LessFlexibleContext lessContext { get; set; }
        protected abstract string PrimaryKey { get; }
        protected abstract string TableName { get; }

        public Model GetModel(object id)
        {
            var model = lessContext.db.Sql(@"select * from " + TableName + " where " + PrimaryKey + " = @0", id).QuerySingle<Model>();
            return model;
        }

        public List<Model> GetModels()
        {
            var list = lessContext.db.Sql(@"select * from " + TableName).QueryMany<Model>();
            return list;
        }


    }
}

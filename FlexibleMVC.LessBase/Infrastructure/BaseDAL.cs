using FlexibleMVC.LessBase.Context;
using System.Collections.Generic;

namespace FlexibleMVC.LessBase.Infrastructure
{
    public abstract class BaseDAL<Model> : IBaseDAL
    {
        public LessFlexibleContext lessContext { get; set; }
        protected abstract string TableName{get;}

        public List<Model> GetModels()
        {
            List<Model> list = lessContext.db.Sql(@"select * from " + TableName).QueryMany<Model>();
            return list;
        }


    }
}

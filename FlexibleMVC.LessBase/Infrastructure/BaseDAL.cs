using FlexibleMVC.LessBase.Context;
using System.Collections.Generic;
using System.Data;

namespace FlexibleMVC.LessBase.Infrastructure
{
    public abstract class BaseDAL<Model> : IBaseDAL
    {
        public LessFlexibleContext lessContext { get; set; }
        protected abstract string PrimaryKey { get; }
        protected abstract string TableName { get; }

        public int Delete(object id)
        {
            int rowsAffected = lessContext.db.Delete(TableName)
                .Where(PrimaryKey, id)
                .Execute();
            return rowsAffected;
        }

        public Model GetModel(object id)
        {
            var model = lessContext.db.Sql(@"select * from " + TableName + " where " + PrimaryKey + " = @0", id).QuerySingle<Model>();
            return model;
        }

        public dynamic GetDynamicModel(object id)
        {
            var model = lessContext.db.Sql(@"select * from " + TableName + " where " + PrimaryKey + " = @0", id).QuerySingle<dynamic>();
            return model;
        }

        public List<Model> GetModels(string where = "", string orderBy = "", int currentPage = 1, int itemsPerPage = 0)
        {
            var builder = lessContext.db.Select<Model>("*").From(TableName);
            if (!string.IsNullOrEmpty(where))
                builder.Where(where);

            if (!string.IsNullOrEmpty(orderBy))
                builder.OrderBy(orderBy);

            if (itemsPerPage != 0)
            {
                if (string.IsNullOrEmpty(orderBy))
                    builder.OrderBy(PrimaryKey + " desc");
                builder.Paging(currentPage, itemsPerPage);
            }

            return builder.QueryMany();
        }

        public List<dynamic> GetDynamicModels(string where = "", string orderBy = "", int currentPage = 1, int itemsPerPage = 0)
        {
            var builder = lessContext.db.Select<dynamic>("*").From(TableName);
            if (!string.IsNullOrEmpty(where))
                builder.Where(where);

            if (!string.IsNullOrEmpty(orderBy))
                builder.OrderBy(orderBy);

            if (itemsPerPage != 0)
            {
                if (string.IsNullOrEmpty(orderBy))
                    builder.OrderBy(PrimaryKey + " desc");
                builder.Paging(currentPage, itemsPerPage);
            }

            return builder.QueryMany();
        }

        public DataTable GetDataTable(string where = "", string orderBy = "", int currentPage = 1, int itemsPerPage = 0)
        {
            var builder = lessContext.db.Select<DataTable>("*").From(TableName);
            if (!string.IsNullOrEmpty(where))
                builder.Where(where);

            if (!string.IsNullOrEmpty(orderBy))
                builder.OrderBy(orderBy);

            if (itemsPerPage != 0)
            {
                if (string.IsNullOrEmpty(orderBy))
                    builder.OrderBy(PrimaryKey + " desc");
                builder.Paging(currentPage, itemsPerPage);
            }

            return builder.QuerySingle();
        }



    }
}

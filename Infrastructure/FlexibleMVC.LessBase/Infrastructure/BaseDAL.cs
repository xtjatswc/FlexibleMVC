using FlexibleMVC.LessBase.Context;
using FluentData;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FlexibleMVC.LessBase.Infrastructure
{
    public abstract class BaseDAL<Model> : IBaseDAL
    {
        public LessFlexibleContext lessContext { get; set; }
        protected abstract string PrimaryKey { get; }
        protected abstract string TableName { get; }
        protected abstract IDbContext Db { get; }

        public BaseDAL(LessFlexibleContext lessContext)
        {
            this.lessContext = lessContext;
        }

        public int Delete(object id)
        {
            int rowsAffected = Db.Delete(TableName)
                .Where(PrimaryKey, id)
                .Execute();
            return rowsAffected;
        }

        public Model GetModel(object id)
        {
            var model = Db.Sql(@"select * from " + TableName + " where " + PrimaryKey + " = @0", id).QuerySingle<Model>();
            return model;
        }

        public dynamic GetDynamicModel(object id)
        {
            var model = Db.Sql(@"select * from " + TableName + " where " + PrimaryKey + " = @0", id).QuerySingle<dynamic>();
            return model;
        }

        public List<Model> GetModels(string where = "", string orderBy = "", int currentPage = 1, int itemsPerPage = 0)
        {
            var builder = Db.Select<Model>("*").From(TableName);
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
            var builder = Db.Select<dynamic>("*").From(TableName);
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
            var builder = Db.Select<DataTable>("*").From(TableName);
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

        public string GenerateEntity()
        {
            DataTable tbl = GetDataTable(where:"1=2");
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn column in tbl.Columns)
            {
                sb.AppendLine("public " + column.DataType.Name + " " + column.ColumnName + "{ get; set; }");
            }
            return sb.ToString();

        }

        public int Update(Model model)
        {
            int rowsAffected = Db.Update<Model>(TableName, model)
            .AutoMap(x => (x as BaseModel).ID)
            .Where(x => (x as BaseModel).ID)
            .Execute();
            return rowsAffected;
        }

    }
}

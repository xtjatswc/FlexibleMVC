using FlexibleMVC.Base.Tools;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Infrastructure.Attribute;
using FluentData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace FlexibleMVC.LessBase.Infrastructure
{
    public class BaseDAL<Model> : IBaseDAL
    {
        public LessFlexibleContext lessContext { get; set; }

        private string _primaryKey;
        protected string PrimaryKey
        {
            get
            {
                if (!string.IsNullOrEmpty(_primaryKey))
                    return _primaryKey;

                PropertyInfo[] peroperties = typeof(Model).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo property in peroperties)
                {
                    object[] objs = property.GetCustomAttributes(typeof(PrimaryKeyAttribute), true);
                    if (objs.Length > 0)
                    {
                        _primaryKey = property.Name;
                        return _primaryKey;
                    }
                }

                throw new Exception($"实体类{TableName}未设置主键");
            }
        }
        private string _tableName;
        protected string TableName
        {
            get
            {
                if (string.IsNullOrEmpty(_tableName))
                {
                    object[] objs = typeof(Model).GetCustomAttributes(typeof(TableNameAttribute), true);
                    if (objs.Length > 0)
                    {
                        _tableName = (objs[0] as TableNameAttribute).Description;
                    }
                    else
                    {
                        _tableName = typeof(Model).Name;
                    }
                }

                return _tableName;
            }
        }
        protected IDbContext Db { get; set; }

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

        /// <summary>
        /// 假删，更新表中的IsDeleted字段为1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteExt(object id)
        {
            int rowsAffected = Db.Sql($"update {TableName} set IsDeleted = 1 where {PrimaryKey} = @0")
            .Parameters(id)
            .Execute();
            return rowsAffected;
        }

        public Model GetModel(object id)
        {
            var model = Db.Sql(@"select * from " + TableName + " where " + PrimaryKey + " = @0", id).QuerySingle<Model>();
            return model;
        }

        public Model GetModel(Model condition, params Expression<Func<Model, object>>[] ignorePropertyExpressions)
        {
            string sWhere = " 1=1 ";
            var parameters = new List<object>();
            for (int i = 0; i < ignorePropertyExpressions.Length; i++)
            {
                var ignorePropertyExpression = ignorePropertyExpressions[i];
                var item = new PropertyExpressionParser<Model>(condition, ignorePropertyExpression);
                sWhere += $" and {item.Name} = @{i} ";
                parameters.Add(item.Value);
            }

            var model = Db.Sql(@"select * from " + TableName + " where " + sWhere, parameters.ToArray()).QuerySingle<Model>();
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
            DataTable tbl = GetDataTable(where: "1=2");
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn column in tbl.Columns)
            {
                sb.AppendLine("public " + column.DataType.Name + " " + column.ColumnName + "{ get; set; }");
            }
            return sb.ToString();

        }

        public int Update(Model model, Expression<Func<Model, object>> expression)
        {
            int rowsAffected = Db.Update<Model>(TableName, model)
            .AutoMap(expression)
            .Where(expression)
            .Execute();
            return rowsAffected;
        }

        public int Insert(Model model)
        {
            int rowsAffected = Db.Insert<Model>(TableName, model).Execute();
            return rowsAffected;
        }

        public object InsertReturnLastId(Model model, Expression<Func<Model, object>> expression)
        {
            return Db.Insert<Model>(TableName, model)
            .AutoMap(expression)
            .ExecuteReturnLastId<object>();
        }

    }
}

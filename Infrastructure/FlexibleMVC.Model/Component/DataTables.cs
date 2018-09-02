using FlexibleMVC.Base.JsonConfig;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Model.Component
{
    /// <summary>
    /// DataTables参数
    /// </summary>
    public class DataTablesParameters
    {
        /// <summary>
        /// 请求次数计数器
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// 第一条数据的起始位置
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 每页显示的数据条数
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 数据列
        /// </summary>
        public List<DataTablesColumns> Columns;

        /// <summary>
        /// 排序
        /// </summary>
        public List<DataTablesOrder> Order { get; set; }

        /// <summary>
        /// 全局搜索
        /// </summary>
        public DataTablesSearch Search { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderBy
        {
            get
            {
                var orderBy = Columns != null && Columns.Any() && Order != null && Order.Any()
                    ? Columns[Order[0].Column].Data
                    : string.Empty;

                if (string.IsNullOrEmpty(orderBy))
                    return "";

                return orderBy + " " + OrderDir;
            }
        }

        /// <summary>
        /// 排序模式
        /// </summary>
        private string OrderDir
        {
            get
            {
                return Order != null && Order.Any()
                    ? Order[0].Dir
                    : "desc";
            }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        public List<DataTablesColumns> WhereEach()
        {
            if (Columns != null && Columns.Any())
            {
                return Columns.Where(o => o.Orderable && !string.IsNullOrEmpty(o.Search.Value)).ToList();
            }

            return default(List<DataTablesColumns>);
        }

        /// <summary>
        /// 获取查询参数
        /// </summary>
        public static DataTablesParameters GetParameters(NameValueCollection form)
        {
            var para = new DataTablesParameters
            {
                Draw = Convert.ToInt32(form["draw"]),
                Start = Convert.ToInt32(form["start"]),
                Length = Convert.ToInt32(form["length"]),
            };

            para.Search = new DataTablesSearch();
            para.Search.Value = form["search[value]"];
            para.Search.Regex = Convert.ToBoolean(form["search[regex]"]);

            para.Order = new List<DataTablesOrder>();
            para.Columns = new List<DataTablesColumns>();

            int i = 0;
            while (true)
            {
                //排序
                var orderCol = form[$"order[{i}][column]"];
                if (orderCol == null) break;

                para.Order.Add(new DataTablesOrder { Column = Convert.ToInt32(orderCol), Dir = form[$"order[{i}][dir]"] });

                i++;
            }

            i = 0;
            while (true)
            {
                //列
                var col = form[$"columns[{i}][data]"];
                if (col == null) break;

                para.Columns.Add(new DataTablesColumns
                {
                    Data = col,
                    Name = form[$"columns[{i}][name]"],
                    Searchable = Convert.ToBoolean(form[$"columns[{i}][searchable]"]),
                    Orderable = Convert.ToBoolean(form[$"columns[{i}][orderable]"]),
                    Search = new DataTablesSearch
                    {
                        Value = form[$"columns[{i}][search][value]"].Replace("'", "''"),
                        Regex = Convert.ToBoolean(form[$"columns[{i}][search][regex]"]),
                    }
                });

                i++;
            }

            return para;
        }
    }

    /// <summary>
    ///     排序
    /// </summary>
    public class DataTablesOrder
    {
        /// <summary>
        ///     排序的列的索引
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        ///     排序模式
        /// </summary>
        public string Dir { get; set; }
    }

    /// <summary>
    ///     数据列
    /// </summary>
    public class DataTablesColumns
    {
        /// <summary>
        ///     数据源
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     是否可以被搜索
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        ///     是否可以排序
        /// </summary>
        public bool Orderable { get; set; }

        /// <summary>
        ///     搜索
        /// </summary>
        public DataTablesSearch Search { get; set; }
    }

    /// <summary>
    ///     搜索
    /// </summary>
    public class DataTablesSearch
    {
        /// <summary>
        ///     全局的搜索条件的值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     是否为正则表达式处理
        /// </summary>
        public bool Regex { get; set; }
    }

    public class DataTablesResult<TEntity>
    {
        public DataTablesResult(int drawParam, int recordsTotalParam, int recordsFilteredParam, List<TEntity> dataParam)
        {
            draw = drawParam;
            recordsTotal = recordsTotalParam;
            recordsFiltered = recordsFilteredParam;
            data = dataParam;
        }
        public DataTablesResult(string errorParam)
        {
            error = errorParam;
        }
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<TEntity> data { get; set; }
        public string error { get; set; }
    }
}

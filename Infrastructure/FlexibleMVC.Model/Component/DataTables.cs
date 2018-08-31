using FlexibleMVC.Base.JsonConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Model.Component
{
    /// <summary>
    ///     DataTables参数
    /// </summary>
    public class DataTablesParameters
    {
        /// <summary>
        ///     请求次数计数器
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        ///     第一条数据的起始位置
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        ///     每页显示的数据条数
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        ///     数据列
        /// </summary>
        private List<DataTablesColumns> _columns;
        public List<Dictionary<string, string>> Columns
        {
            get
            {
                return null;
            }
            set
            {
                string json = JsonUtil.ToJson(value);
                _columns = JsonUtil.ToObj<List<DataTablesColumns>>(json);
            }
        }

        /// <summary>
        ///     排序
        /// </summary>
        private List<DataTablesOrder> _order;
        public List<Dictionary<string, string>> Order
        {
            get
            {
                return null;
            }
            set
            {
                string json = JsonUtil.ToJson(value);
                _order = JsonUtil.ToObj<List<DataTablesOrder>>(json);
            }
        }

        /// <summary>
        ///     搜索
        /// </summary>
        public DataTablesSearch Search { get; set; }

        /// <summary>
        ///     排序字段
        /// </summary>
        public string OrderBy
        {
            get
            {
                var orderBy = _columns != null && _columns.Any() && _order != null && _order.Any()
                    ? _columns[_order[0].Column].Data
                    : string.Empty;

                if (string.IsNullOrEmpty(orderBy))
                    return "";

                return orderBy + " " + OrderDir;
            }
        }

        /// <summary>
        ///     排序模式
        /// </summary>
        private DataTablesOrderDir OrderDir
        {
            get
            {
                return _order != null && _order.Any()
                    ? _order[0].Dir
                    : DataTablesOrderDir.Desc;
            }
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
        public DataTablesOrderDir Dir { get; set; }
    }

    /// <summary>
    ///     排序模式
    /// </summary>
    public enum DataTablesOrderDir
    {
        /// <summary>
        ///     正序
        /// </summary>
        Asc,

        /// <summary>
        ///     倒序
        /// </summary>
        Desc
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

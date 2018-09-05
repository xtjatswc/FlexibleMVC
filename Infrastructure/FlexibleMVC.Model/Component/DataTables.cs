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
        /// 排序字段
        /// </summary>
        public string OrderBy { get; set; }
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

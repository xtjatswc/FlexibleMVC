using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FlexibleMVC.Base.Tools;
using System.Web;
using System.Text;

namespace FlexibleMVC.Base.Mvc.AcResult
{
    public class BaseExcelResult : FileResult
    {
        private string fileName;
        public string FileName
        {
            get => fileName;
            set
            {
                fileName = value;
                FileDownloadName = HttpUtility.UrlEncode(FileName + ".xls", Encoding.UTF8);
            }
        }

        public DataTable Tbl { get; set; }

        private const string contentType = "application/vnd.ms-excel";

        public BaseExcelResult() : base(contentType)
        {
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            var ms = Tbl.Export2Excel(FileName);

            response.BufferOutput = true;
            response.ContentEncoding = Encoding.UTF8;
            response.Charset = "utf-8";
            //response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName + ".xls", Encoding.UTF8));
            response.BinaryWrite(ms.GetBuffer());
            response.End();
        }
    }
}

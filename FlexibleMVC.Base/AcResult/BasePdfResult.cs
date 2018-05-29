using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FlexibleMVC.Base.AcResult
{
    public class BasePdfResult : ActionResult
    {
        public ViewDataDictionary ViewData { get; set; } = new ViewDataDictionary();

        public string ViewName { get; set; }
        public string FileName { get; set; }
        public bool IsDownload { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (String.IsNullOrEmpty(ViewName))
            {
                //ViewName = context.RouteData.GetRequiredString("action");
                ExecuteViewResult execResult = new ExecuteViewResult();
                this.ViewName = execResult.GetViewName(context);
            }
            if (ViewData == null)
            {
                ViewData = context.Controller.ViewData;

            }
            ViewEngineResult result = ViewEngines.Engines.FindView(context, ViewName, null);
            IView View = result.View;

            StringBuilder sbHtml = new StringBuilder();
            TextWriter txtWriter = new StringWriter(sbHtml);
            ViewContext viewContext = new ViewContext(context, View, ViewData, context.Controller.TempData, txtWriter);
            result.View.Render(viewContext, txtWriter);

            HttpResponseBase httpResponse = context.HttpContext.Response;
            httpResponse.ContentType = System.Net.Mime.MediaTypeNames.Application.Pdf;

            //是否直接下载pdf文件，或者在浏览器中预览呈现
            string attachment = (IsDownload ? "attachment;": "");
            FileName = string.IsNullOrEmpty(FileName) ? context.RouteData.GetRequiredString("action") : FileName;
            context.HttpContext.Response.AppendHeader("Content-Disposition", string.Format("{1}filename={0}.pdf", FileName, attachment));

            HtmlToPdf(sbHtml, httpResponse);

            result.ViewEngine.ReleaseView(context, View);
        }

        private static void HtmlToPdf(StringBuilder sbHtml, HttpResponseBase httpResponse)
        {
            using (Document document = new Document(PageSize.A4, 4, 4, 4, 4))
            {
                using (PdfWriter pdfWriter = PdfWriter.GetInstance(document, httpResponse.OutputStream))
                {
                    document.Open();
                    FontFactory.RegisterDirectories();//注册系统中所支持的字体
                    XMLWorkerHelper worker = XMLWorkerHelper.GetInstance();
                    //UnicodeFontFactory 自定义实现解决itextsharp.xmlworker 不支持中文的问题
                    string html = sbHtml.ToString();
                    worker.ParseXHtml(pdfWriter, document, new MemoryStream(Encoding.UTF8.GetBytes(html)), null, Encoding.UTF8, new UnicodeFontFactory());
                    document.Close();
                }
            }
        }
    }

    public class UnicodeFontFactory : FontFactoryImp
    {
        static UnicodeFontFactory()
        {

        }
        public override Font GetFont(string fontname, string encoding, bool embedded, float size, int style, BaseColor color, bool cached)
        {
            return FontFactory.GetFont(fontname: "微软雅黑", encoding: BaseFont.IDENTITY_H, embedded: BaseFont.EMBEDDED, size: size, style: style, color: color, cached: cached);
        }
    }
}

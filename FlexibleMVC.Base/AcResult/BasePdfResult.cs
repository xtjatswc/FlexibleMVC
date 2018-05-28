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
        public BasePdfResult() : this(null, null) { }

        public BasePdfResult(string viewName) : this(null, viewName) { }

        public BasePdfResult(object model) : this(model, null) { }

        public BasePdfResult(object model, string viewName)
        {
            this.ViewName = viewName;
            ViewData = null != model ? new ViewDataDictionary(model) : null;
        }

        public ViewDataDictionary ViewData { get; set; } = new ViewDataDictionary();

        public string ViewName { get; set; }

        public IView View { get; set; }

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
            View = result.View;

            StringBuilder sbHtml = new StringBuilder();
            TextWriter txtWriter = new StringWriter(sbHtml);
            ViewContext viewContext = new ViewContext(context, View, ViewData, context.Controller.TempData, txtWriter);
            result.View.Render(viewContext, txtWriter);

            HttpResponseBase httpResponse = context.HttpContext.Response;
            httpResponse.ContentType = System.Net.Mime.MediaTypeNames.Application.Pdf;

            //加入此头部文件会直接下载pdf文件，而不是在浏览器中预览呈现
            //context.HttpContext.Response.AppendHeader("Content-Disposition", string.Format("attachment;filename={0}.pdf", ViewName));

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
                    document.NewPage();
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
            return FontFactory.GetFont("微软雅黑", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }
    }
}

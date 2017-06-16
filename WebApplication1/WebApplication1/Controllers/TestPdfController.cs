using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;
using PdfSharp.Pdf;
using System.IO;
using System.Net.Http.Headers;
using PdfSharp.Drawing;

namespace WebApplication1.Controllers
{
    public class TestPdfController : ApiController
    {
        private AppDBContext db = new AppDBContext();


        public static String generateHtmlOutOfObject(IQueryable tableData)
        {
            String html = "";

            foreach (Mesto m in tableData)
            {
                html += "<tr><td>" + m.Naziv + "</td><td>" + m.Postanski_broj + "</td></tr>";
            }
            return html;

        }


        // GET: api/Analitika_magacinske_kartice
        [Route("api/pdf")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public HttpResponseMessage getPdf()
        {
            /*    
                PdfDocument doc = new PdfDocument();
                var page= doc.AddPage();
                MemoryStream memoryStream = new MemoryStream();
                var response=Request.CreateResponse(HttpStatusCode.OK);

                //content length for use in header
                XGraphics gfx = XGraphics.FromPdfPage(page);
                //200
                //successfulResponse.Clear();
                XSize size = gfx.PageSize;

                XGraphicsPath path = new XGraphicsPath();

                path.AddString("PDFshar", new XFontFamily("Verdana"), XFontStyle.BoldItalic, 10,new XRect(0, size.Height / 10, size.Width, 0), XStringFormats.Center);
                path.AddString("PDsasaFshar", new XFontFamily("Verdana"), XFontStyle.BoldItalic, 10, new XRect(0, size.Height/2, size.Width, 0), XStringFormats.TopLeft);

                gfx.DrawPath(new XPen(XColor.FromName("red")), path);

                doc.Save(memoryStream, false);
                var buffer = memoryStream.GetBuffer();
                var contentLength = buffer.Length;
                var statuscode = HttpStatusCode.OK;
                response = Request.CreateResponse(statuscode);
                response.Content = new StreamContent(new MemoryStream(buffer));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentLength = contentLength;
                memoryStream.Close();
                ContentDispositionHeaderValue contentDisposition = null;
                if (ContentDispositionHeaderValue.TryParse("inline; filename=f", out contentDisposition))
                {
                    response.Content.Headers.ContentDisposition = contentDisposition;
                }
                return response;
            }   

          */
            //String html = "<body><table style='border:solid'><tr><td>sasasa</td></table></body>";

            var mesto = db.Mesto;

            Byte[] res = null;
            var response = Request.CreateResponse(HttpStatusCode.OK);
            String html = generateHtmlOutOfObject(mesto);
            using (MemoryStream ms = new MemoryStream())
            {

                var statuscode = HttpStatusCode.OK;
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                var buffer = ms.GetBuffer();
                var contentLength = buffer.Length;
                res = ms.ToArray();

                response = Request.CreateResponse(statuscode);
                response.Content = new StreamContent(new MemoryStream(buffer));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentLength = contentLength;
                ms.Close();
            }
            return response;
        }
    }
}
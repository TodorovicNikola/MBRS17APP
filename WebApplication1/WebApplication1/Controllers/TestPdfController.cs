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
using PdfSharp;
using System.IO;
using System.Net.Http.Headers;
using PdfSharp.Drawing;
using MigraDoc;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WebApplication1.Controllers
{
    public class TestPdfController : ApiController
    {
        private static AppDBContext db = new AppDBContext();

        /*public static String dataToString(Object o)
        {
            if (o.GetType()!=typeof(String) && o.GetType()!=typeof(int) && o.GetType()!=typeof(double) && o.GetType()!=typeof(DateTime))
            {
                return "";
            }
            return o.ToString();

        }
        */

        public static String generateHtmlOutOfObject(DbSet<Roba> tableData)
        {
            String html = "<body style='text-align:center;align:center'>";
            html += "<h2>Izvestaj: " + "Roba</h2> </br>";
            html += "<table border=1 style='width:100%;border-collapse: collapse;'>";
            int i = 0;
            foreach (var row in tableData)
            {
                if (i++ == 0)
                {
                    html += "<tr>";
                    html += "<td>" + "Id" + "</td>";
                    html += "<td>" + "Naziv" + "</td>";
                    html += "<td>" + "Grupa_roba" + "</td>";
                    html += "<td>" + "Preduzece" + "</td>";
                    html += "<td>" + "Jedinica_mere" + "</td>";
                    html += "</tr>";
                }
                html += "<tr>";
                html += "<td>" + row.Id + "</td>";
                html += "<td>" + row.Naziv + "</td>";
                html += row.Grupa_roba == null ? "<td></td>" : "<td>" + row.Grupa_roba.Naziv + "</td>";
                html += row.Preduzece == null ? "<td></td>" : "<td>" + row.Preduzece.Naziv + "</td>";
                html += row.Jedinica_mere == null ? "<td></td>" : "<td>" + row.Jedinica_mere.Oznaka + "</td>";
                html += "</tr>";
            }
            html += "</table></body>";
            return html;

        }


        // GET: api/Analitika_magacinske_kartice
        [Route("api/pdf")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public HttpResponseMessage getPdf()
        {
            /*var data = db.Roba;

            Byte[] res = null;
            var response = Request.CreateResponse(HttpStatusCode.OK);
            String html = generateHtmlOutOfObject(data);
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
            */
            /*
            
            var html = String.Format("<body>Hello world: {0}</body>",
        DateTime.Now);

           
            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(html);
            var contentLength = pdfBytes.Length;
            //res = ms.ToArray();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response = Request.CreateResponse(statuscode);
            var ms = new MemoryStream(pdfBytes);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentLength = contentLength;
            //ms.Close();
            //ms.Close();
            //ms.Flush();
            */
            //PDFCre
            using (var ms = new MemoryStream())
            {

                //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                using (var doc = new Document())
                {

                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {

                        doc.Open();

                        var data = db.Roba;
                        String html = "<body>asada</body>";
                        using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
                        {

                            //HTMLWorker doesn't read a string directly but instead needs a TextReader (which StringReader subclasses)
                            using (var sr = new StringReader(html))
                            {

                                //Parse the HTML
                                htmlWorker.Parse(sr);
                            }
                        }
                        doc.Close();
                      
                        var response = Request.CreateResponse(HttpStatusCode.OK);
                        Byte[] bytes;
                        bytes = ms.ToArray();
                        var msNew = new MemoryStream(bytes);
                        response.Content = new StreamContent(msNew);
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                        response.Content.Headers.ContentLength = bytes.Length;
                        ms.Close();
                        ms.Flush();
                        return response;

                    }
                }
            }


        }
    }
}
 
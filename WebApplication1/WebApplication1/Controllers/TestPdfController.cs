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
            var data = db.Roba;

            
            String html = generateHtmlOutOfObject(data);
            //var htmlContent = String.Format("<body>Hello world: {0}</body>",
        //DateTime.Now);
            var statuscode = HttpStatusCode.OK;
            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(html);
            var contentLength = pdfBytes.Length;
            //res = ms.ToArray();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response = Request.CreateResponse(statuscode);
            response.Content = new StreamContent(new MemoryStream(pdfBytes));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentLength = contentLength;
            //ms.Close();
            return response;
        }
    }
}
 
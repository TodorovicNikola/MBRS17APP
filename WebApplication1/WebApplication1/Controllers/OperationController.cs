// DO NOT CHANGE THIS CODE
// TEMPLATE operations.ftl
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
using System.IO;
using System.Net.Http.Headers;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WebApplication1.Controllers
{
    public partial class OperationController : ApiController
    {
    	private AppDBContext db = new AppDBContext();
    			 public static String generateHtmlOutOfFaktura(DbSet<Faktura> tableData)
        {
            String html = "<body style='text-align:center;align:center'>";
            html+="<h2>Izve�taj: "+"Faktura</h2> </br>";
            html += "<table border=1 style='width:100%;border-collapse: collapse;'>";
            int i = 0;
            foreach (var row in tableData)
            {
            if(i++==0)
            {
                html += "<tr>";
		            		html+="<td>"+"Id"+"</td>";
		            		html+="<td>"+"Broj_fakture"+"</td>";
		            		html+="<td>"+"Datum_fakture"+"</td>";
		            		html+="<td>"+"Datum_valute"+"</td>";
		            		html+="<td>"+"Ukupan_rabat"+"</td>";
		            		html+="<td>"+"Ukupan_iznos_bez_PDV_a"+"</td>";
		            		html+="<td>"+"Ukupan_PDV"+"</td>";
		            		html+="<td>"+"Ukupno_za_placanje"+"</td>";
		            		html+="<td>"+"Poslovna_godina"+"</td>";
		            		html+="<td>"+"Poslovni_partner"+"</td>";
                html += "</tr>";
            }
            html+="<tr>";
		        	html+="<td>"+row.Id+"</td>";
		        	html+="<td>"+row.Broj_fakture+"</td>";
		        	html+="<td>"+row.Datum_fakture+"</td>";
		        	html+="<td>"+row.Datum_valute+"</td>";
		        	html+="<td>"+row.Ukupan_rabat+"</td>";
		        	html+="<td>"+row.Ukupan_iznos_bez_PDV_a+"</td>";
		        	html+="<td>"+row.Ukupan_PDV+"</td>";
		        	html+="<td>"+row.Ukupno_za_placanje+"</td>";
		            html+=row.Poslovna_godina==null?"<td></td>":"<td>"+row.Poslovna_godina.Godina+"</td>";
		            html+=row.Poslovni_partner==null?"<td></td>":"<td>"+row.Poslovni_partner.Naziv+"</td>";
            html+="</tr>";
            }
            html += "</table></body>";
            return html;

        }
        [ResponseType(typeof(void))]
        [HttpGet]
        [Route("api/operations/Generisi_izvestaj")]
        public HttpResponseMessage Generisi_izvestaj(String jezik)
        {
        
        	var response = Request.CreateResponse(HttpStatusCode.OK);
        	
        	using (var ms = new MemoryStream())
            {
                //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                using (var doc = new Document())
                {
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        doc.Open();
                        var data = db.Faktura;
                        String html = generateHtmlOutOfFaktura(data);
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
                      
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        Byte[] bytes;
                        bytes = ms.ToArray();
                        var msNew = new MemoryStream(bytes);
                        response.Content = new StreamContent(msNew);
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                        response.Content.Headers.ContentLength = bytes.Length;
                        ms.Close();
                        ms.Flush();
                        

                    }
                }
            }
        	return response;
        }
        
        [ResponseType(typeof(Faktura))]
        [Route("api/operations/Proknjizi")]
        [HttpPost]
        public IHttpActionResult Proknjizi(Faktura faktura)
        {
            // USER CODE STARTS HERE

			return Ok();
			// USER CODE ENDS HERE
        }
        
        [ResponseType(typeof(Robna_kartica))]
        [Route("api/operations/Generisi_statistiku")]
        [HttpPost]
        public IHttpActionResult Generisi_statistiku(Robna_kartica robna_kartica)
        {
            // USER CODE STARTS HERE

			return Ok();
			// USER CODE ENDS HERE
        }
        

        
    }
}
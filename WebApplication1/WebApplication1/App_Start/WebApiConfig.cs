using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using WebApplication1.Models;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            
            			builder.EntitySet<Jedinica_mere>("Jedinica_mere");
			builder.EntitySet<Stopa_PDV_a>("Stopa_PDV_a");
			builder.EntitySet<Analitika_magacinske_kartice>("Analitika_magacinske_kartice");
			builder.EntitySet<Poslovni_partner>("Poslovni_partner");
			builder.EntitySet<Mesto>("Mesto");
			builder.EntitySet<Grupa_roba>("Grupa_roba");
			builder.EntitySet<PDV>("PDV");
			builder.EntitySet<Poslovna_godina>("Poslovna_godina");
			builder.EntitySet<Roba>("Roba");
			builder.EntitySet<Prijemni_dokument>("Prijemni_dokument");
			builder.EntitySet<Faktura>("Faktura");
			builder.EntitySet<Preduzece>("Preduzece");
			builder.EntitySet<Robna_kartica>("Robna_kartica");
			builder.EntitySet<Magacin>("Magacin");
			builder.EntitySet<Stavka_dokumenta>("Stavka_dokumenta");

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}

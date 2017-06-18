using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public partial class OperationController : ApiController
    {
        [ResponseType(typeof(String))]
        [HttpGet]
        [Route("api/operations/getSomething")]
        public IHttpActionResult GetSomething()
        {
            Faktura faktura = new Faktura();
            return Ok(faktura.MethodThatReturnsSomething());
        }
    }
}

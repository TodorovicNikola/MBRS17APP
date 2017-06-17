using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using WebApplication1.Models;
using System.Web.Http.Description;

namespace WebApplication1.Controllers
{
    public class FakturaController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Faktura
        
        [EnableQuery]
        [ResponseType(typeof(IQueryable<Faktura>))]
        public async Task<IHttpActionResult> GetFaktura()
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Faktura);
        }

		// GET: odata/Faktura(5)
        [EnableQuery]
        [ResponseType(typeof(Faktura))]
        public async Task<IHttpActionResult> GetFaktura([FromODataUri] int key)
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Faktura.Where(faktura => faktura.Id == key));
            //return SingleResult.Create(db.Mesto.Where(mesto => mesto.Id == key));
        }

      

        // PUT: odata/Faktura(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Faktura> patch)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Faktura faktura = await db.Faktura.FindAsync(key);
            if (faktura == null)
            {
                return NotFound();
            }

            patch.Put(faktura);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FakturaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(faktura);
        }

        // POST: odata/Faktura
        public async Task<IHttpActionResult> Post(Faktura faktura)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Faktura.Add(faktura);
            await db.SaveChangesAsync();

            return Created(faktura);
        }

        // PATCH: odata/Faktura(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Faktura> patch)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Faktura faktura = await db.Faktura.FindAsync(key);
            if (faktura == null)
            {
                return NotFound();
            }

            patch.Patch(faktura);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FakturaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(faktura);
        }

        // DELETE: odata/Faktura(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Faktura faktura = await db.Faktura.FindAsync(key);
            if (faktura == null)
            {
                return NotFound();
            }

            db.Faktura.Remove(faktura);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FakturaExists(int key)
        {
            return db.Faktura.Count(e => e.Id == key) > 0;
        }
    }
}

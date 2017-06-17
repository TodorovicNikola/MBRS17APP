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

namespace WebApplication1.Controllers
{
    public class FakturaController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Faktura
        [EnableQuery]
        public IQueryable<Faktura> GetFaktura()
        {
            return db.Faktura;
        }

        // GET: odata/Faktura(5)
        [EnableQuery]
        public SingleResult<Faktura> GetFaktura([FromODataUri] int key)
        {
            return SingleResult.Create(db.Faktura.Where(faktura => faktura.Id == key));
        }

        // PUT: odata/Faktura(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Faktura> patch)
        {
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

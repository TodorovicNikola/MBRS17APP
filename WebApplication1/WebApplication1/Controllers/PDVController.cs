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
    public class PDVController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/PDV
        [EnableQuery]
        public IQueryable<PDV> GetPDV()
        {
            return db.PDV;
        }

        // GET: odata/PDV(5)
        [EnableQuery]
        public SingleResult<PDV> GetPDV([FromODataUri] int key)
        {
            return SingleResult.Create(db.PDV.Where(pdv => pdv.Id == key));
        }

        // PUT: odata/PDV(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<PDV> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PDV pdv = await db.PDV.FindAsync(key);
            if (pdv == null)
            {
                return NotFound();
            }

            patch.Put(pdv);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PDVExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(pdv);
        }

        // POST: odata/PDV
        public async Task<IHttpActionResult> Post(PDV pdv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PDV.Add(pdv);
            await db.SaveChangesAsync();

            return Created(pdv);
        }

        // PATCH: odata/PDV(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<PDV> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PDV pdv = await db.PDV.FindAsync(key);
            if (pdv == null)
            {
                return NotFound();
            }

            patch.Patch(pdv);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PDVExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(pdv);
        }

        // DELETE: odata/PDV(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            PDV pdv = await db.PDV.FindAsync(key);
            if (pdv == null)
            {
                return NotFound();
            }

            db.PDV.Remove(pdv);
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

        private bool PDVExists(int key)
        {
            return db.PDV.Count(e => e.Id == key) > 0;
        }
    }
}

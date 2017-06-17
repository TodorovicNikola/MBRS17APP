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
    public class Stopa_PDV_aController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Stopa_PDV_a
        [EnableQuery]
        public IQueryable<Stopa_PDV_a> GetStopa_PDV_a()
        {
            return db.Stopa_PDV_a;
        }

        // GET: odata/Stopa_PDV_a(5)
        [EnableQuery]
        public SingleResult<Stopa_PDV_a> GetStopa_PDV_a([FromODataUri] int key)
        {
            return SingleResult.Create(db.Stopa_PDV_a.Where(stopa_pdv_a => stopa_pdv_a.Id == key));
        }

        // PUT: odata/Stopa_PDV_a(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Stopa_PDV_a> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Stopa_PDV_a stopa_pdv_a = await db.Stopa_PDV_a.FindAsync(key);
            if (stopa_pdv_a == null)
            {
                return NotFound();
            }

            patch.Put(stopa_pdv_a);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Stopa_PDV_aExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(stopa_pdv_a);
        }

        // POST: odata/Stopa_PDV_a
        public async Task<IHttpActionResult> Post(Stopa_PDV_a stopa_pdv_a)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stopa_PDV_a.Add(stopa_pdv_a);
            await db.SaveChangesAsync();

            return Created(stopa_pdv_a);
        }

        // PATCH: odata/Stopa_PDV_a(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Stopa_PDV_a> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Stopa_PDV_a stopa_pdv_a = await db.Stopa_PDV_a.FindAsync(key);
            if (stopa_pdv_a == null)
            {
                return NotFound();
            }

            patch.Patch(stopa_pdv_a);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Stopa_PDV_aExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(stopa_pdv_a);
        }

        // DELETE: odata/Stopa_PDV_a(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Stopa_PDV_a stopa_pdv_a = await db.Stopa_PDV_a.FindAsync(key);
            if (stopa_pdv_a == null)
            {
                return NotFound();
            }

            db.Stopa_PDV_a.Remove(stopa_pdv_a);
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

        private bool Stopa_PDV_aExists(int key)
        {
            return db.Stopa_PDV_a.Count(e => e.Id == key) > 0;
        }
    }
}

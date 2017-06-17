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
    public class Robna_karticaController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Robna_kartica
        [EnableQuery]
        public IQueryable<Robna_kartica> GetRobna_kartica()
        {
            return db.Robna_kartica;
        }

        // GET: odata/Robna_kartica(5)
        [EnableQuery]
        public SingleResult<Robna_kartica> GetRobna_kartica([FromODataUri] int key)
        {
            return SingleResult.Create(db.Robna_kartica.Where(robna_kartica => robna_kartica.Id == key));
        }

        // PUT: odata/Robna_kartica(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Robna_kartica> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Robna_kartica robna_kartica = await db.Robna_kartica.FindAsync(key);
            if (robna_kartica == null)
            {
                return NotFound();
            }

            patch.Put(robna_kartica);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Robna_karticaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(robna_kartica);
        }

        // POST: odata/Robna_kartica
        public async Task<IHttpActionResult> Post(Robna_kartica robna_kartica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Robna_kartica.Add(robna_kartica);
            await db.SaveChangesAsync();

            return Created(robna_kartica);
        }

        // PATCH: odata/Robna_kartica(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Robna_kartica> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Robna_kartica robna_kartica = await db.Robna_kartica.FindAsync(key);
            if (robna_kartica == null)
            {
                return NotFound();
            }

            patch.Patch(robna_kartica);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Robna_karticaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(robna_kartica);
        }

        // DELETE: odata/Robna_kartica(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Robna_kartica robna_kartica = await db.Robna_kartica.FindAsync(key);
            if (robna_kartica == null)
            {
                return NotFound();
            }

            db.Robna_kartica.Remove(robna_kartica);
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

        private bool Robna_karticaExists(int key)
        {
            return db.Robna_kartica.Count(e => e.Id == key) > 0;
        }
    }
}

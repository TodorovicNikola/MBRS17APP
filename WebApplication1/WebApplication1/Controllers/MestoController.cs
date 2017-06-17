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
    public class MestoController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Mesto
        [EnableQuery]
        public IQueryable<Mesto> GetMesto()
        {
            return db.Mesto;
        }

        // GET: odata/Mesto(5)
        [EnableQuery]
        public SingleResult<Mesto> GetMesto([FromODataUri] int key)
        {
            return SingleResult.Create(db.Mesto.Where(mesto => mesto.Id == key));
        }

        // PUT: odata/Mesto(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Mesto> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mesto mesto = await db.Mesto.FindAsync(key);
            if (mesto == null)
            {
                return NotFound();
            }

            patch.Put(mesto);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MestoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(mesto);
        }

        // POST: odata/Mesto
        public async Task<IHttpActionResult> Post(Mesto mesto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mesto.Add(mesto);
            await db.SaveChangesAsync();

            return Created(mesto);
        }

        // PATCH: odata/Mesto(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Mesto> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mesto mesto = await db.Mesto.FindAsync(key);
            if (mesto == null)
            {
                return NotFound();
            }

            patch.Patch(mesto);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MestoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(mesto);
        }

        // DELETE: odata/Mesto(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Mesto mesto = await db.Mesto.FindAsync(key);
            if (mesto == null)
            {
                return NotFound();
            }

            db.Mesto.Remove(mesto);
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

        private bool MestoExists(int key)
        {
            return db.Mesto.Count(e => e.Id == key) > 0;
        }
    }
}

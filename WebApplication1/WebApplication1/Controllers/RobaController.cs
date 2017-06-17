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
    public class RobaController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Roba
        [EnableQuery]
        public IQueryable<Roba> GetRoba()
        {
            return db.Roba;
        }

        // GET: odata/Roba(5)
        [EnableQuery]
        public SingleResult<Roba> GetRoba([FromODataUri] int key)
        {
            return SingleResult.Create(db.Roba.Where(roba => roba.Id == key));
        }

        // PUT: odata/Roba(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Roba> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Roba roba = await db.Roba.FindAsync(key);
            if (roba == null)
            {
                return NotFound();
            }

            patch.Put(roba);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RobaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(roba);
        }

        // POST: odata/Roba
        public async Task<IHttpActionResult> Post(Roba roba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roba.Add(roba);
            await db.SaveChangesAsync();

            return Created(roba);
        }

        // PATCH: odata/Roba(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Roba> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Roba roba = await db.Roba.FindAsync(key);
            if (roba == null)
            {
                return NotFound();
            }

            patch.Patch(roba);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RobaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(roba);
        }

        // DELETE: odata/Roba(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Roba roba = await db.Roba.FindAsync(key);
            if (roba == null)
            {
                return NotFound();
            }

            db.Roba.Remove(roba);
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

        private bool RobaExists(int key)
        {
            return db.Roba.Count(e => e.Id == key) > 0;
        }
    }
}

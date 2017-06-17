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
    public class Grupa_robaController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Grupa_roba
        [EnableQuery]
        public IQueryable<Grupa_roba> GetGrupa_roba()
        {
            return db.Grupa_roba;
        }

        // GET: odata/Grupa_roba(5)
        [EnableQuery]
        public SingleResult<Grupa_roba> GetGrupa_roba([FromODataUri] int key)
        {
            return SingleResult.Create(db.Grupa_roba.Where(grupa_roba => grupa_roba.Id == key));
        }

        // PUT: odata/Grupa_roba(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Grupa_roba> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Grupa_roba grupa_roba = await db.Grupa_roba.FindAsync(key);
            if (grupa_roba == null)
            {
                return NotFound();
            }

            patch.Put(grupa_roba);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Grupa_robaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(grupa_roba);
        }

        // POST: odata/Grupa_roba
        public async Task<IHttpActionResult> Post(Grupa_roba grupa_roba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grupa_roba.Add(grupa_roba);
            await db.SaveChangesAsync();

            return Created(grupa_roba);
        }

        // PATCH: odata/Grupa_roba(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Grupa_roba> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Grupa_roba grupa_roba = await db.Grupa_roba.FindAsync(key);
            if (grupa_roba == null)
            {
                return NotFound();
            }

            patch.Patch(grupa_roba);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Grupa_robaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(grupa_roba);
        }

        // DELETE: odata/Grupa_roba(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Grupa_roba grupa_roba = await db.Grupa_roba.FindAsync(key);
            if (grupa_roba == null)
            {
                return NotFound();
            }

            db.Grupa_roba.Remove(grupa_roba);
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

        private bool Grupa_robaExists(int key)
        {
            return db.Grupa_roba.Count(e => e.Id == key) > 0;
        }
    }
}

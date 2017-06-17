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
    public class Jedinica_mereController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Jedinica_mere
        [EnableQuery]
        public IQueryable<Jedinica_mere> GetJedinica_mere()
        {
            return db.Jedinica_mere;
        }

        // GET: odata/Jedinica_mere(5)
        [EnableQuery]
        public SingleResult<Jedinica_mere> GetJedinica_mere([FromODataUri] int key)
        {
            return SingleResult.Create(db.Jedinica_mere.Where(jedinica_mere => jedinica_mere.Id == key));
        }

        // PUT: odata/Jedinica_mere(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Jedinica_mere> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Jedinica_mere jedinica_mere = await db.Jedinica_mere.FindAsync(key);
            if (jedinica_mere == null)
            {
                return NotFound();
            }

            patch.Put(jedinica_mere);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Jedinica_mereExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(jedinica_mere);
        }

        // POST: odata/Jedinica_mere
        public async Task<IHttpActionResult> Post(Jedinica_mere jedinica_mere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jedinica_mere.Add(jedinica_mere);
            await db.SaveChangesAsync();

            return Created(jedinica_mere);
        }

        // PATCH: odata/Jedinica_mere(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Jedinica_mere> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Jedinica_mere jedinica_mere = await db.Jedinica_mere.FindAsync(key);
            if (jedinica_mere == null)
            {
                return NotFound();
            }

            patch.Patch(jedinica_mere);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Jedinica_mereExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(jedinica_mere);
        }

        // DELETE: odata/Jedinica_mere(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Jedinica_mere jedinica_mere = await db.Jedinica_mere.FindAsync(key);
            if (jedinica_mere == null)
            {
                return NotFound();
            }

            db.Jedinica_mere.Remove(jedinica_mere);
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

        private bool Jedinica_mereExists(int key)
        {
            return db.Jedinica_mere.Count(e => e.Id == key) > 0;
        }
    }
}

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
    public class PreduzeceController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Preduzece
        [EnableQuery]
        public IQueryable<Preduzece> GetPreduzece()
        {
            return db.Preduzece;
        }

        // GET: odata/Preduzece(5)
        [EnableQuery]
        public SingleResult<Preduzece> GetPreduzece([FromODataUri] int key)
        {
            return SingleResult.Create(db.Preduzece.Where(preduzece => preduzece.Id == key));
        }

        // PUT: odata/Preduzece(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Preduzece> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Preduzece preduzece = await db.Preduzece.FindAsync(key);
            if (preduzece == null)
            {
                return NotFound();
            }

            patch.Put(preduzece);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreduzeceExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(preduzece);
        }

        // POST: odata/Preduzece
        public async Task<IHttpActionResult> Post(Preduzece preduzece)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Preduzece.Add(preduzece);
            await db.SaveChangesAsync();

            return Created(preduzece);
        }

        // PATCH: odata/Preduzece(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Preduzece> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Preduzece preduzece = await db.Preduzece.FindAsync(key);
            if (preduzece == null)
            {
                return NotFound();
            }

            patch.Patch(preduzece);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreduzeceExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(preduzece);
        }

        // DELETE: odata/Preduzece(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Preduzece preduzece = await db.Preduzece.FindAsync(key);
            if (preduzece == null)
            {
                return NotFound();
            }

            db.Preduzece.Remove(preduzece);
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

        private bool PreduzeceExists(int key)
        {
            return db.Preduzece.Count(e => e.Id == key) > 0;
        }
    }
}

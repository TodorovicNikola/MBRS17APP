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
    public class Stavka_dokumentaController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Stavka_dokumenta
        [EnableQuery]
        public IQueryable<Stavka_dokumenta> GetStavka_dokumenta()
        {
            return db.Stavka_dokumenta;
        }

        // GET: odata/Stavka_dokumenta(5)
        [EnableQuery]
        public SingleResult<Stavka_dokumenta> GetStavka_dokumenta([FromODataUri] int key)
        {
            return SingleResult.Create(db.Stavka_dokumenta.Where(stavka_dokumenta => stavka_dokumenta.Id == key));
        }

        // PUT: odata/Stavka_dokumenta(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Stavka_dokumenta> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Stavka_dokumenta stavka_dokumenta = await db.Stavka_dokumenta.FindAsync(key);
            if (stavka_dokumenta == null)
            {
                return NotFound();
            }

            patch.Put(stavka_dokumenta);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Stavka_dokumentaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(stavka_dokumenta);
        }

        // POST: odata/Stavka_dokumenta
        public async Task<IHttpActionResult> Post(Stavka_dokumenta stavka_dokumenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stavka_dokumenta.Add(stavka_dokumenta);
            await db.SaveChangesAsync();

            return Created(stavka_dokumenta);
        }

        // PATCH: odata/Stavka_dokumenta(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Stavka_dokumenta> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Stavka_dokumenta stavka_dokumenta = await db.Stavka_dokumenta.FindAsync(key);
            if (stavka_dokumenta == null)
            {
                return NotFound();
            }

            patch.Patch(stavka_dokumenta);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Stavka_dokumentaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(stavka_dokumenta);
        }

        // DELETE: odata/Stavka_dokumenta(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Stavka_dokumenta stavka_dokumenta = await db.Stavka_dokumenta.FindAsync(key);
            if (stavka_dokumenta == null)
            {
                return NotFound();
            }

            db.Stavka_dokumenta.Remove(stavka_dokumenta);
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

        private bool Stavka_dokumentaExists(int key)
        {
            return db.Stavka_dokumenta.Count(e => e.Id == key) > 0;
        }
    }
}

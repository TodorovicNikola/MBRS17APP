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
using System.Web.Http.Description;

namespace WebApplication1.Controllers
{
    public class Analitika_magacinske_karticeController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Analitika_magacinske_kartice
        
        [EnableQuery]
        [ResponseType(typeof(IQueryable<Analitika_magacinske_kartice>))]
        public async Task<IHttpActionResult> GetAnalitika_magacinske_kartice()
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Analitika_magacinske_kartice);
        }

		// GET: odata/Analitika_magacinske_kartice(5)
        [EnableQuery]
        [ResponseType(typeof(Analitika_magacinske_kartice))]
        public async Task<IHttpActionResult> GetAnalitika_magacinske_kartice([FromODataUri] int key)
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Analitika_magacinske_kartice.Where(analitika_magacinske_kartice => analitika_magacinske_kartice.Id == key));
            //return SingleResult.Create(db.Mesto.Where(mesto => mesto.Id == key));
        }

      

        // PUT: odata/Analitika_magacinske_kartice(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Analitika_magacinske_kartice> patch)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Validate(patch.GetEntity());

            if (!ModelState.IsValid || !patch.GetEntity().ValidateOcl())
            {
                return BadRequest(ModelState);
            }

            Analitika_magacinske_kartice analitika_magacinske_kartice = await db.Analitika_magacinske_kartice.FindAsync(key);
            if (analitika_magacinske_kartice == null)
            {
                return NotFound();
            }

            patch.Put(analitika_magacinske_kartice);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Analitika_magacinske_karticeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(analitika_magacinske_kartice);
        }

        // POST: odata/Analitika_magacinske_kartice
        public async Task<IHttpActionResult> Post(Analitika_magacinske_kartice analitika_magacinske_kartice)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid || !analitika_magacinske_kartice.ValidateOcl())
            {
                return BadRequest(ModelState);
            }

            db.Analitika_magacinske_kartice.Add(analitika_magacinske_kartice);
            await db.SaveChangesAsync();

            return Created(analitika_magacinske_kartice);
        }

        // PATCH: odata/Analitika_magacinske_kartice(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Analitika_magacinske_kartice> patch)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Validate(patch.GetEntity());

            if (!ModelState.IsValid || !patch.GetEntity().ValidateOcl())
            {
                return BadRequest(ModelState);
            }

            Analitika_magacinske_kartice analitika_magacinske_kartice = await db.Analitika_magacinske_kartice.FindAsync(key);
            if (analitika_magacinske_kartice == null)
            {
                return NotFound();
            }

            patch.Patch(analitika_magacinske_kartice);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Analitika_magacinske_karticeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(analitika_magacinske_kartice);
        }

        // DELETE: odata/Analitika_magacinske_kartice(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Analitika_magacinske_kartice analitika_magacinske_kartice = await db.Analitika_magacinske_kartice.FindAsync(key);
            if (analitika_magacinske_kartice == null)
            {
                return NotFound();
            }

            db.Analitika_magacinske_kartice.Remove(analitika_magacinske_kartice);
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

        private bool Analitika_magacinske_karticeExists(int key)
        {
            return db.Analitika_magacinske_kartice.Count(e => e.Id == key) > 0;
        }
    }
}

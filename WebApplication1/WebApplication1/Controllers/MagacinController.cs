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
    public class MagacinController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Magacin
        
        [EnableQuery]
        [ResponseType(typeof(IQueryable<Magacin>))]
        public async Task<IHttpActionResult> GetMagacin()
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Magacin);
        }

		// GET: odata/Magacin(5)
        [EnableQuery]
        [ResponseType(typeof(Magacin))]
        public async Task<IHttpActionResult> GetMagacin([FromODataUri] int key)
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Magacin.Where(magacin => magacin.Id == key));
            //return SingleResult.Create(db.Mesto.Where(mesto => mesto.Id == key));
        }

      

        // PUT: odata/Magacin(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Magacin> patch)
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

            Magacin magacin = await db.Magacin.FindAsync(key);
            if (magacin == null)
            {
                return NotFound();
            }

            patch.Put(magacin);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagacinExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(magacin);
        }

        // POST: odata/Magacin
        public async Task<IHttpActionResult> Post(Magacin magacin)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid || !magacin.ValidateOcl())
            {
                return BadRequest(ModelState);
            }

            db.Magacin.Add(magacin);
            await db.SaveChangesAsync();

            return Created(magacin);
        }

        // PATCH: odata/Magacin(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Magacin> patch)
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

            Magacin magacin = await db.Magacin.FindAsync(key);
            if (magacin == null)
            {
                return NotFound();
            }

            patch.Patch(magacin);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagacinExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(magacin);
        }

        // DELETE: odata/Magacin(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Magacin magacin = await db.Magacin.FindAsync(key);
            if (magacin == null)
            {
                return NotFound();
            }

            db.Magacin.Remove(magacin);
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

        private bool MagacinExists(int key)
        {
            return db.Magacin.Count(e => e.Id == key) > 0;
        }
    }
}

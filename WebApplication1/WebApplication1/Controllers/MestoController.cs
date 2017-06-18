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
    public class MestoController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Mesto
        
        [EnableQuery]
        [ResponseType(typeof(IQueryable<Mesto>))]
        public async Task<IHttpActionResult> GetMesto()
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Mesto);
        }

		// GET: odata/Mesto(5)
        [EnableQuery]
        [ResponseType(typeof(Mesto))]
        public async Task<IHttpActionResult> GetMesto([FromODataUri] int key)
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Mesto.Where(mesto => mesto.Id == key));
            //return SingleResult.Create(db.Mesto.Where(mesto => mesto.Id == key));
        }

      

        // PUT: odata/Mesto(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Mesto> patch)
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
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid || !mesto.ValidateOcl())
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
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Validate(patch.GetEntity());

            if (!ModelState.IsValid || !patch.GetEntity().ValidateOcl())
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
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
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

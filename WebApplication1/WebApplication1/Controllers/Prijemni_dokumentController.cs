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
    public class Prijemni_dokumentController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Prijemni_dokument
        
        [EnableQuery]
        [ResponseType(typeof(IQueryable<Prijemni_dokument>))]
        public async Task<IHttpActionResult> GetPrijemni_dokument()
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Prijemni_dokument);
        }

		// GET: odata/Prijemni_dokument(5)
        [EnableQuery]
        [ResponseType(typeof(Prijemni_dokument))]
        public async Task<IHttpActionResult> GetPrijemni_dokument([FromODataUri] int key)
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Prijemni_dokument.Where(prijemni_dokument => prijemni_dokument.Id == key));
            //return SingleResult.Create(db.Mesto.Where(mesto => mesto.Id == key));
        }

      

        // PUT: odata/Prijemni_dokument(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Prijemni_dokument> patch)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Prijemni_dokument prijemni_dokument = await db.Prijemni_dokument.FindAsync(key);
            if (prijemni_dokument == null)
            {
                return NotFound();
            }

            patch.Put(prijemni_dokument);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Prijemni_dokumentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(prijemni_dokument);
        }

        // POST: odata/Prijemni_dokument
        public async Task<IHttpActionResult> Post(Prijemni_dokument prijemni_dokument)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prijemni_dokument.Add(prijemni_dokument);
            await db.SaveChangesAsync();

            return Created(prijemni_dokument);
        }

        // PATCH: odata/Prijemni_dokument(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Prijemni_dokument> patch)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Prijemni_dokument prijemni_dokument = await db.Prijemni_dokument.FindAsync(key);
            if (prijemni_dokument == null)
            {
                return NotFound();
            }

            patch.Patch(prijemni_dokument);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Prijemni_dokumentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(prijemni_dokument);
        }

        // DELETE: odata/Prijemni_dokument(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Prijemni_dokument prijemni_dokument = await db.Prijemni_dokument.FindAsync(key);
            if (prijemni_dokument == null)
            {
                return NotFound();
            }

            db.Prijemni_dokument.Remove(prijemni_dokument);
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

        private bool Prijemni_dokumentExists(int key)
        {
            return db.Prijemni_dokument.Count(e => e.Id == key) > 0;
        }
    }
}

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
    public class Poslovni_partnerController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Poslovni_partner
        
        [EnableQuery]
        [ResponseType(typeof(IQueryable<Poslovni_partner>))]
        public async Task<IHttpActionResult> GetPoslovni_partner()
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Poslovni_partner);
        }

		// GET: odata/Poslovni_partner(5)
        [EnableQuery]
        [ResponseType(typeof(Poslovni_partner))]
        public async Task<IHttpActionResult> GetPoslovni_partner([FromODataUri] int key)
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Poslovni_partner.Where(poslovni_partner => poslovni_partner.Id == key));
            //return SingleResult.Create(db.Mesto.Where(mesto => mesto.Id == key));
        }

      

        // PUT: odata/Poslovni_partner(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Poslovni_partner> patch)
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

            Poslovni_partner poslovni_partner = await db.Poslovni_partner.FindAsync(key);
            if (poslovni_partner == null)
            {
                return NotFound();
            }

            patch.Put(poslovni_partner);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Poslovni_partnerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(poslovni_partner);
        }

        // POST: odata/Poslovni_partner
        public async Task<IHttpActionResult> Post(Poslovni_partner poslovni_partner)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid || !poslovni_partner.ValidateOcl())
            {
                return BadRequest(ModelState);
            }

            db.Poslovni_partner.Add(poslovni_partner);
            await db.SaveChangesAsync();

            return Created(poslovni_partner);
        }

        // PATCH: odata/Poslovni_partner(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Poslovni_partner> patch)
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

            Poslovni_partner poslovni_partner = await db.Poslovni_partner.FindAsync(key);
            if (poslovni_partner == null)
            {
                return NotFound();
            }

            patch.Patch(poslovni_partner);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Poslovni_partnerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(poslovni_partner);
        }

        // DELETE: odata/Poslovni_partner(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Poslovni_partner poslovni_partner = await db.Poslovni_partner.FindAsync(key);
            if (poslovni_partner == null)
            {
                return NotFound();
            }

            db.Poslovni_partner.Remove(poslovni_partner);
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

        private bool Poslovni_partnerExists(int key)
        {
            return db.Poslovni_partner.Count(e => e.Id == key) > 0;
        }
    }
}

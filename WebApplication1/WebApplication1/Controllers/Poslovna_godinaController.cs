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
    public class Poslovna_godinaController : ODataController
    {
        private AppDBContext db = new AppDBContext();

        // GET: odata/Poslovna_godina
        
        [EnableQuery]
        [ResponseType(typeof(IQueryable<Poslovna_godina>))]
        public async Task<IHttpActionResult> GetPoslovna_godina()
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Poslovna_godina);
        }

		// GET: odata/Poslovna_godina(5)
        [EnableQuery]
        [ResponseType(typeof(Poslovna_godina))]
        public async Task<IHttpActionResult> GetPoslovna_godina([FromODataUri] int key)
        {
            if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            return Ok(db.Poslovna_godina.Where(poslovna_godina => poslovna_godina.Id == key));
            //return SingleResult.Create(db.Mesto.Where(mesto => mesto.Id == key));
        }

      

        // PUT: odata/Poslovna_godina(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Poslovna_godina> patch)
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

            Poslovna_godina poslovna_godina = await db.Poslovna_godina.FindAsync(key);
            if (poslovna_godina == null)
            {
                return NotFound();
            }

            patch.Put(poslovna_godina);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Poslovna_godinaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(poslovna_godina);
        }

        // POST: odata/Poslovna_godina
        public async Task<IHttpActionResult> Post(Poslovna_godina poslovna_godina)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Poslovna_godina.Add(poslovna_godina);
            await db.SaveChangesAsync();

            return Created(poslovna_godina);
        }

        // PATCH: odata/Poslovna_godina(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Poslovna_godina> patch)
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

            Poslovna_godina poslovna_godina = await db.Poslovna_godina.FindAsync(key);
            if (poslovna_godina == null)
            {
                return NotFound();
            }

            patch.Patch(poslovna_godina);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Poslovna_godinaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(poslovna_godina);
        }

        // DELETE: odata/Poslovna_godina(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
        	if (!LoginController.CheckAuthorizationForRequest(Request))
            {
                return Unauthorized();
            }
            Poslovna_godina poslovna_godina = await db.Poslovna_godina.FindAsync(key);
            if (poslovna_godina == null)
            {
                return NotFound();
            }

            db.Poslovna_godina.Remove(poslovna_godina);
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

        private bool Poslovna_godinaExists(int key)
        {
            return db.Poslovna_godina.Count(e => e.Id == key) > 0;
        }
    }
}

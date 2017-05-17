using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Analitika_magacinske_karticeController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Analitika_magacinske_kartice
        public IQueryable<Analitika_magacinske_kartice> GetAnalitika_magacinske_kartice()
        {
            return db.Analitika_magacinske_kartice;
        }

        // GET: api/Analitika_magacinske_kartice/5
        [ResponseType(typeof(Analitika_magacinske_kartice))]
        public IHttpActionResult GetAnalitika_magacinske_kartice(int id)
        {
            Analitika_magacinske_kartice analitika_magacinske_kartice = db. Analitika_magacinske_kartice.Find(id);
            if (analitika_magacinske_kartice == null)
            {
                return NotFound();
            }

            return Ok(analitika_magacinske_kartice);
        }

        // PUT: api/Analitika_magacinske_kartice/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnalitika_magacinske_kartice(int id,  Analitika_magacinske_kartice analitika_magacinske_kartice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != analitika_magacinske_kartice.Id)
            {
                return BadRequest();
            }

            db.Entry(analitika_magacinske_kartice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Analitika_magacinske_karticeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Analitika_magacinske_kartice
        [ResponseType(typeof(Analitika_magacinske_kartice))]
        public IHttpActionResult PostAnalitika_magacinske_kartice(Analitika_magacinske_kartice analitika_magacinske_kartice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Analitika_magacinske_kartice.Add(analitika_magacinske_kartice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = analitika_magacinske_kartice.Id }, analitika_magacinske_kartice);
        }

        // DELETE: api/Analitika_magacinske_kartice/5
        [ResponseType(typeof(Analitika_magacinske_kartice))]
        public IHttpActionResult DeleteAnalitika_magacinske_kartice(int id)
        {
            Analitika_magacinske_kartice analitika_magacinske_kartice = db.Analitika_magacinske_kartice.Find(id);
            if (analitika_magacinske_kartice == null)
            {
                return NotFound();
            }

            db.Analitika_magacinske_kartice.Remove(analitika_magacinske_kartice);
            db.SaveChanges();

            return Ok(analitika_magacinske_kartice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Analitika_magacinske_karticeExists(int id)
        {
            return db.Analitika_magacinske_kartice.Count(e => e.Id == id) > 0;
        }
    }
}
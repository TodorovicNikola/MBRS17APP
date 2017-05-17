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
    public class Jedinica_mereController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Jedinica_mere
        public IQueryable<Jedinica_mere> GetJedinica_mere()
        {
            return db.Jedinica_mere;
        }

        // GET: api/Jedinica_mere/5
        [ResponseType(typeof(Jedinica_mere))]
        public IHttpActionResult GetJedinica_mere(int id)
        {
            Jedinica_mere jedinica_mere = db. Jedinica_mere.Find(id);
            if (jedinica_mere == null)
            {
                return NotFound();
            }

            return Ok(jedinica_mere);
        }

        // PUT: api/Jedinica_mere/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJedinica_mere(int id,  Jedinica_mere jedinica_mere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jedinica_mere.Id)
            {
                return BadRequest();
            }

            db.Entry(jedinica_mere).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Jedinica_mereExists(id))
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

        // POST: api/Jedinica_mere
        [ResponseType(typeof(Jedinica_mere))]
        public IHttpActionResult PostJedinica_mere(Jedinica_mere jedinica_mere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jedinica_mere.Add(jedinica_mere);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jedinica_mere.Id }, jedinica_mere);
        }

        // DELETE: api/Jedinica_mere/5
        [ResponseType(typeof(Jedinica_mere))]
        public IHttpActionResult DeleteJedinica_mere(int id)
        {
            Jedinica_mere jedinica_mere = db.Jedinica_mere.Find(id);
            if (jedinica_mere == null)
            {
                return NotFound();
            }

            db.Jedinica_mere.Remove(jedinica_mere);
            db.SaveChanges();

            return Ok(jedinica_mere);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Jedinica_mereExists(int id)
        {
            return db.Jedinica_mere.Count(e => e.Id == id) > 0;
        }
    }
}
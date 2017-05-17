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
    public class Robna_karticaController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Robna_kartica
        public IQueryable<Robna_kartica> GetRobna_kartica()
        {
            return db.Robna_kartica;
        }

        // GET: api/Robna_kartica/5
        [ResponseType(typeof(Robna_kartica))]
        public IHttpActionResult GetRobna_kartica(int id)
        {
            Robna_kartica robna_kartica = db. Robna_kartica.Find(id);
            if (robna_kartica == null)
            {
                return NotFound();
            }

            return Ok(robna_kartica);
        }

        // PUT: api/Robna_kartica/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRobna_kartica(int id,  Robna_kartica robna_kartica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != robna_kartica.Id)
            {
                return BadRequest();
            }

            db.Entry(robna_kartica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Robna_karticaExists(id))
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

        // POST: api/Robna_kartica
        [ResponseType(typeof(Robna_kartica))]
        public IHttpActionResult PostRobna_kartica(Robna_kartica robna_kartica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Robna_kartica.Add(robna_kartica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = robna_kartica.Id }, robna_kartica);
        }

        // DELETE: api/Robna_kartica/5
        [ResponseType(typeof(Robna_kartica))]
        public IHttpActionResult DeleteRobna_kartica(int id)
        {
            Robna_kartica robna_kartica = db.Robna_kartica.Find(id);
            if (robna_kartica == null)
            {
                return NotFound();
            }

            db.Robna_kartica.Remove(robna_kartica);
            db.SaveChanges();

            return Ok(robna_kartica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Robna_karticaExists(int id)
        {
            return db.Robna_kartica.Count(e => e.Id == id) > 0;
        }
    }
}
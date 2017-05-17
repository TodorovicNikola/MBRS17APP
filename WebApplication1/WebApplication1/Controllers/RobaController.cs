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
    public class RobaController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Roba
        public IQueryable<Roba> GetRoba()
        {
            return db.Roba;
        }

        // GET: api/Roba/5
        [ResponseType(typeof(Roba))]
        public IHttpActionResult GetRoba(int id)
        {
            Roba roba = db. Roba.Find(id);
            if (roba == null)
            {
                return NotFound();
            }

            return Ok(roba);
        }

        // PUT: api/Roba/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoba(int id,  Roba roba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roba.Id)
            {
                return BadRequest();
            }

            db.Entry(roba).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RobaExists(id))
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

        // POST: api/Roba
        [ResponseType(typeof(Roba))]
        public IHttpActionResult PostRoba(Roba roba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roba.Add(roba);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roba.Id }, roba);
        }

        // DELETE: api/Roba/5
        [ResponseType(typeof(Roba))]
        public IHttpActionResult DeleteRoba(int id)
        {
            Roba roba = db.Roba.Find(id);
            if (roba == null)
            {
                return NotFound();
            }

            db.Roba.Remove(roba);
            db.SaveChanges();

            return Ok(roba);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RobaExists(int id)
        {
            return db.Roba.Count(e => e.Id == id) > 0;
        }
    }
}
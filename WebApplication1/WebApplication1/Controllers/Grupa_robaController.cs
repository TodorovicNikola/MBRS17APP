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
    public class Grupa_robaController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Grupa_roba
        public IQueryable<Grupa_roba> GetGrupa_roba()
        {
            return db.Grupa_roba;
        }

        // GET: api/Grupa_roba/5
        [ResponseType(typeof(Grupa_roba))]
        public IHttpActionResult GetGrupa_roba(int id)
        {
            Grupa_roba grupa_roba = db. Grupa_roba.Find(id);
            if (grupa_roba == null)
            {
                return NotFound();
            }

            return Ok(grupa_roba);
        }

        // PUT: api/Grupa_roba/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrupa_roba(int id,  Grupa_roba grupa_roba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grupa_roba.Id)
            {
                return BadRequest();
            }

            db.Entry(grupa_roba).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Grupa_robaExists(id))
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

        // POST: api/Grupa_roba
        [ResponseType(typeof(Grupa_roba))]
        public IHttpActionResult PostGrupa_roba(Grupa_roba grupa_roba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grupa_roba.Add(grupa_roba);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = grupa_roba.Id }, grupa_roba);
        }

        // DELETE: api/Grupa_roba/5
        [ResponseType(typeof(Grupa_roba))]
        public IHttpActionResult DeleteGrupa_roba(int id)
        {
            Grupa_roba grupa_roba = db.Grupa_roba.Find(id);
            if (grupa_roba == null)
            {
                return NotFound();
            }

            db.Grupa_roba.Remove(grupa_roba);
            db.SaveChanges();

            return Ok(grupa_roba);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Grupa_robaExists(int id)
        {
            return db.Grupa_roba.Count(e => e.Id == id) > 0;
        }
    }
}
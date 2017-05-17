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
    public class MagacinController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Magacin
        public IQueryable<Magacin> GetMagacin()
        {
            return db.Magacin;
        }

        // GET: api/Magacin/5
        [ResponseType(typeof(Magacin))]
        public IHttpActionResult GetMagacin(int id)
        {
            Magacin magacin = db. Magacin.Find(id);
            if (magacin == null)
            {
                return NotFound();
            }

            return Ok(magacin);
        }

        // PUT: api/Magacin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMagacin(int id,  Magacin magacin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != magacin.Id)
            {
                return BadRequest();
            }

            db.Entry(magacin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagacinExists(id))
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

        // POST: api/Magacin
        [ResponseType(typeof(Magacin))]
        public IHttpActionResult PostMagacin(Magacin magacin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Magacin.Add(magacin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = magacin.Id }, magacin);
        }

        // DELETE: api/Magacin/5
        [ResponseType(typeof(Magacin))]
        public IHttpActionResult DeleteMagacin(int id)
        {
            Magacin magacin = db.Magacin.Find(id);
            if (magacin == null)
            {
                return NotFound();
            }

            db.Magacin.Remove(magacin);
            db.SaveChanges();

            return Ok(magacin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MagacinExists(int id)
        {
            return db.Magacin.Count(e => e.Id == id) > 0;
        }
    }
}
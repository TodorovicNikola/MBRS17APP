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
    public class Prijemni_dokumentController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Prijemni_dokument
        public IQueryable<Prijemni_dokument> GetPrijemni_dokument()
        {
            return db.Prijemni_dokument;
        }

        // GET: api/Prijemni_dokument/5
        [ResponseType(typeof(Prijemni_dokument))]
        public IHttpActionResult GetPrijemni_dokument(int id)
        {
            Prijemni_dokument prijemni_dokument = db. Prijemni_dokument.Find(id);
            if (prijemni_dokument == null)
            {
                return NotFound();
            }

            return Ok(prijemni_dokument);
        }

        // PUT: api/Prijemni_dokument/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrijemni_dokument(int id,  Prijemni_dokument prijemni_dokument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prijemni_dokument.Id)
            {
                return BadRequest();
            }

            db.Entry(prijemni_dokument).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Prijemni_dokumentExists(id))
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

        // POST: api/Prijemni_dokument
        [ResponseType(typeof(Prijemni_dokument))]
        public IHttpActionResult PostPrijemni_dokument(Prijemni_dokument prijemni_dokument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prijemni_dokument.Add(prijemni_dokument);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prijemni_dokument.Id }, prijemni_dokument);
        }

        // DELETE: api/Prijemni_dokument/5
        [ResponseType(typeof(Prijemni_dokument))]
        public IHttpActionResult DeletePrijemni_dokument(int id)
        {
            Prijemni_dokument prijemni_dokument = db.Prijemni_dokument.Find(id);
            if (prijemni_dokument == null)
            {
                return NotFound();
            }

            db.Prijemni_dokument.Remove(prijemni_dokument);
            db.SaveChanges();

            return Ok(prijemni_dokument);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Prijemni_dokumentExists(int id)
        {
            return db.Prijemni_dokument.Count(e => e.Id == id) > 0;
        }
    }
}
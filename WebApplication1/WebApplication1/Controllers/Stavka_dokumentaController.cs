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
    public class Stavka_dokumentaController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Stavka_dokumenta
        public IQueryable<Stavka_dokumenta> GetStavka_dokumenta()
        {
            return db.Stavka_dokumenta;
        }

        // GET: api/Stavka_dokumenta/5
        [ResponseType(typeof(Stavka_dokumenta))]
        public IHttpActionResult GetStavka_dokumenta(int id)
        {
            Stavka_dokumenta stavka_dokumenta = db. Stavka_dokumenta.Find(id);
            if (stavka_dokumenta == null)
            {
                return NotFound();
            }

            return Ok(stavka_dokumenta);
        }

        // PUT: api/Stavka_dokumenta/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStavka_dokumenta(int id,  Stavka_dokumenta stavka_dokumenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stavka_dokumenta.Id)
            {
                return BadRequest();
            }

            db.Entry(stavka_dokumenta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Stavka_dokumentaExists(id))
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

        // POST: api/Stavka_dokumenta
        [ResponseType(typeof(Stavka_dokumenta))]
        public IHttpActionResult PostStavka_dokumenta(Stavka_dokumenta stavka_dokumenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stavka_dokumenta.Add(stavka_dokumenta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stavka_dokumenta.Id }, stavka_dokumenta);
        }

        // DELETE: api/Stavka_dokumenta/5
        [ResponseType(typeof(Stavka_dokumenta))]
        public IHttpActionResult DeleteStavka_dokumenta(int id)
        {
            Stavka_dokumenta stavka_dokumenta = db.Stavka_dokumenta.Find(id);
            if (stavka_dokumenta == null)
            {
                return NotFound();
            }

            db.Stavka_dokumenta.Remove(stavka_dokumenta);
            db.SaveChanges();

            return Ok(stavka_dokumenta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Stavka_dokumentaExists(int id)
        {
            return db.Stavka_dokumenta.Count(e => e.Id == id) > 0;
        }
    }
}
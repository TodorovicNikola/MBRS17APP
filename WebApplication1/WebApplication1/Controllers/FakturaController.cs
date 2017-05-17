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
    public class FakturaController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Faktura
        public IQueryable<Faktura> GetFaktura()
        {
            return db.Faktura;
        }

        // GET: api/Faktura/5
        [ResponseType(typeof(Faktura))]
        public IHttpActionResult GetFaktura(int id)
        {
            Faktura faktura = db. Faktura.Find(id);
            if (faktura == null)
            {
                return NotFound();
            }

            return Ok(faktura);
        }

        // PUT: api/Faktura/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFaktura(int id,  Faktura faktura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faktura.Id)
            {
                return BadRequest();
            }

            db.Entry(faktura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FakturaExists(id))
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

        // POST: api/Faktura
        [ResponseType(typeof(Faktura))]
        public IHttpActionResult PostFaktura(Faktura faktura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Faktura.Add(faktura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = faktura.Id }, faktura);
        }

        // DELETE: api/Faktura/5
        [ResponseType(typeof(Faktura))]
        public IHttpActionResult DeleteFaktura(int id)
        {
            Faktura faktura = db.Faktura.Find(id);
            if (faktura == null)
            {
                return NotFound();
            }

            db.Faktura.Remove(faktura);
            db.SaveChanges();

            return Ok(faktura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FakturaExists(int id)
        {
            return db.Faktura.Count(e => e.Id == id) > 0;
        }
    }
}
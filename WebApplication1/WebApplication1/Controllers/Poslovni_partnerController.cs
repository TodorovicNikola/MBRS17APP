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
    public class Poslovni_partnerController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Poslovni_partner
        public IQueryable<Poslovni_partner> GetPoslovni_partner()
        {
            return db.Poslovni_partner;
        }

        // GET: api/Poslovni_partner/5
        [ResponseType(typeof(Poslovni_partner))]
        public IHttpActionResult GetPoslovni_partner(int id)
        {
            Poslovni_partner poslovni_partner = db. Poslovni_partner.Find(id);
            if (poslovni_partner == null)
            {
                return NotFound();
            }

            return Ok(poslovni_partner);
        }

        // PUT: api/Poslovni_partner/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoslovni_partner(int id,  Poslovni_partner poslovni_partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poslovni_partner.Id)
            {
                return BadRequest();
            }

            db.Entry(poslovni_partner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Poslovni_partnerExists(id))
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

        // POST: api/Poslovni_partner
        [ResponseType(typeof(Poslovni_partner))]
        public IHttpActionResult PostPoslovni_partner(Poslovni_partner poslovni_partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Poslovni_partner.Add(poslovni_partner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = poslovni_partner.Id }, poslovni_partner);
        }

        // DELETE: api/Poslovni_partner/5
        [ResponseType(typeof(Poslovni_partner))]
        public IHttpActionResult DeletePoslovni_partner(int id)
        {
            Poslovni_partner poslovni_partner = db.Poslovni_partner.Find(id);
            if (poslovni_partner == null)
            {
                return NotFound();
            }

            db.Poslovni_partner.Remove(poslovni_partner);
            db.SaveChanges();

            return Ok(poslovni_partner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Poslovni_partnerExists(int id)
        {
            return db.Poslovni_partner.Count(e => e.Id == id) > 0;
        }
    }
}
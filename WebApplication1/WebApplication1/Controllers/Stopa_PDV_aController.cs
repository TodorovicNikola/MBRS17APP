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
    public class Stopa_PDV_aController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Stopa_PDV_a
        public IQueryable<Stopa_PDV_a> GetStopa_PDV_a()
        {
            return db.Stopa_PDV_a;
        }

        // GET: api/Stopa_PDV_a/5
        [ResponseType(typeof(Stopa_PDV_a))]
        public IHttpActionResult GetStopa_PDV_a(int id)
        {
            Stopa_PDV_a stopa_pdv_a = db. Stopa_PDV_a.Find(id);
            if (stopa_pdv_a == null)
            {
                return NotFound();
            }

            return Ok(stopa_pdv_a);
        }

        // PUT: api/Stopa_PDV_a/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStopa_PDV_a(int id,  Stopa_PDV_a stopa_pdv_a)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stopa_pdv_a.Id)
            {
                return BadRequest();
            }

            db.Entry(stopa_pdv_a).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Stopa_PDV_aExists(id))
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

        // POST: api/Stopa_PDV_a
        [ResponseType(typeof(Stopa_PDV_a))]
        public IHttpActionResult PostStopa_PDV_a(Stopa_PDV_a stopa_pdv_a)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stopa_PDV_a.Add(stopa_pdv_a);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stopa_pdv_a.Id }, stopa_pdv_a);
        }

        // DELETE: api/Stopa_PDV_a/5
        [ResponseType(typeof(Stopa_PDV_a))]
        public IHttpActionResult DeleteStopa_PDV_a(int id)
        {
            Stopa_PDV_a stopa_pdv_a = db.Stopa_PDV_a.Find(id);
            if (stopa_pdv_a == null)
            {
                return NotFound();
            }

            db.Stopa_PDV_a.Remove(stopa_pdv_a);
            db.SaveChanges();

            return Ok(stopa_pdv_a);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Stopa_PDV_aExists(int id)
        {
            return db.Stopa_PDV_a.Count(e => e.Id == id) > 0;
        }
    }
}
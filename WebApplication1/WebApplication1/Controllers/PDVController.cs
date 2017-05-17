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
    public class PDVController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/PDV
        public IQueryable<PDV> GetPDV()
        {
            return db.PDV;
        }

        // GET: api/PDV/5
        [ResponseType(typeof(PDV))]
        public IHttpActionResult GetPDV(int id)
        {
            PDV pdv = db. PDV.Find(id);
            if (pdv == null)
            {
                return NotFound();
            }

            return Ok(pdv);
        }

        // PUT: api/PDV/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPDV(int id,  PDV pdv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pdv.Id)
            {
                return BadRequest();
            }

            db.Entry(pdv).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PDVExists(id))
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

        // POST: api/PDV
        [ResponseType(typeof(PDV))]
        public IHttpActionResult PostPDV(PDV pdv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PDV.Add(pdv);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pdv.Id }, pdv);
        }

        // DELETE: api/PDV/5
        [ResponseType(typeof(PDV))]
        public IHttpActionResult DeletePDV(int id)
        {
            PDV pdv = db.PDV.Find(id);
            if (pdv == null)
            {
                return NotFound();
            }

            db.PDV.Remove(pdv);
            db.SaveChanges();

            return Ok(pdv);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PDVExists(int id)
        {
            return db.PDV.Count(e => e.Id == id) > 0;
        }
    }
}
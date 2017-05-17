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
    public class PreduzeceController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Preduzece
        public IQueryable<Preduzece> GetPreduzece()
        {
            return db.Preduzece;
        }

        // GET: api/Preduzece/5
        [ResponseType(typeof(Preduzece))]
        public IHttpActionResult GetPreduzece(int id)
        {
            Preduzece preduzece = db. Preduzece.Find(id);
            if (preduzece == null)
            {
                return NotFound();
            }

            return Ok(preduzece);
        }

        // PUT: api/Preduzece/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPreduzece(int id,  Preduzece preduzece)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preduzece.Id)
            {
                return BadRequest();
            }

            db.Entry(preduzece).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreduzeceExists(id))
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

        // POST: api/Preduzece
        [ResponseType(typeof(Preduzece))]
        public IHttpActionResult PostPreduzece(Preduzece preduzece)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Preduzece.Add(preduzece);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = preduzece.Id }, preduzece);
        }

        // DELETE: api/Preduzece/5
        [ResponseType(typeof(Preduzece))]
        public IHttpActionResult DeletePreduzece(int id)
        {
            Preduzece preduzece = db.Preduzece.Find(id);
            if (preduzece == null)
            {
                return NotFound();
            }

            db.Preduzece.Remove(preduzece);
            db.SaveChanges();

            return Ok(preduzece);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreduzeceExists(int id)
        {
            return db.Preduzece.Count(e => e.Id == id) > 0;
        }
    }
}
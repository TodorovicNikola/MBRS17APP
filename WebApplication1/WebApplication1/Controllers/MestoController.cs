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
    public class MestoController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Mesto
        public IQueryable<Mesto> GetMesto()
        {
            return db.Mesto;
        }

        // GET: api/Mesto/5
        [ResponseType(typeof(Mesto))]
        public IHttpActionResult GetMesto(int id)
        {
            Mesto mesto = db. Mesto.Find(id);
            if (mesto == null)
            {
                return NotFound();
            }

            return Ok(mesto);
        }

        // PUT: api/Mesto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMesto(int id,  Mesto mesto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mesto.Id)
            {
                return BadRequest();
            }

            db.Entry(mesto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MestoExists(id))
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

        // POST: api/Mesto
        [ResponseType(typeof(Mesto))]
        public IHttpActionResult PostMesto(Mesto mesto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!mesto.ValidateEntity())
            {
                Console.WriteLine("OCL NOT PASSED");
                return BadRequest(ModelState);
            }

            db.Mesto.Add(mesto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mesto.Id }, mesto);
        }

        // DELETE: api/Mesto/5
        [ResponseType(typeof(Mesto))]
        public IHttpActionResult DeleteMesto(int id)
        {
            Mesto mesto = db.Mesto.Find(id);
            if (mesto == null)
            {
                return NotFound();
            }

            db.Mesto.Remove(mesto);
            db.SaveChanges();

            return Ok(mesto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MestoExists(int id)
        {
            return db.Mesto.Count(e => e.Id == id) > 0;
        }
    }
}
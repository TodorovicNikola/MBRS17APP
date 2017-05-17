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
    public class Poslovna_godinaController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/Poslovna_godina
        public IQueryable<Poslovna_godina> GetPoslovna_godina()
        {
            return db.Poslovna_godina;
        }

        // GET: api/Poslovna_godina/5
        [ResponseType(typeof(Poslovna_godina))]
        public IHttpActionResult GetPoslovna_godina(int id)
        {
            Poslovna_godina poslovna_godina = db. Poslovna_godina.Find(id);
            if (poslovna_godina == null)
            {
                return NotFound();
            }

            return Ok(poslovna_godina);
        }

        // PUT: api/Poslovna_godina/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoslovna_godina(int id,  Poslovna_godina poslovna_godina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poslovna_godina.Id)
            {
                return BadRequest();
            }

            db.Entry(poslovna_godina).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Poslovna_godinaExists(id))
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

        // POST: api/Poslovna_godina
        [ResponseType(typeof(Poslovna_godina))]
        public IHttpActionResult PostPoslovna_godina(Poslovna_godina poslovna_godina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Poslovna_godina.Add(poslovna_godina);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = poslovna_godina.Id }, poslovna_godina);
        }

        // DELETE: api/Poslovna_godina/5
        [ResponseType(typeof(Poslovna_godina))]
        public IHttpActionResult DeletePoslovna_godina(int id)
        {
            Poslovna_godina poslovna_godina = db.Poslovna_godina.Find(id);
            if (poslovna_godina == null)
            {
                return NotFound();
            }

            db.Poslovna_godina.Remove(poslovna_godina);
            db.SaveChanges();

            return Ok(poslovna_godina);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Poslovna_godinaExists(int id)
        {
            return db.Poslovna_godina.Count(e => e.Id == id) > 0;
        }
    }
}
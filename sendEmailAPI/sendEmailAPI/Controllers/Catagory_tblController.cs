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
using sendEmailAPI;

namespace sendEmailAPI.Controllers
{
    public class Catagory_tblController : ApiController
    {
        private symbolsEntities1 db = new symbolsEntities1();

        // GET: api/Catagory_tbl
        public IQueryable<Catagory_tbl> GetCatagory_tbl()
        {
            return db.Catagory_tbl;
        }

        // GET: api/Catagory_tbl/5
        [ResponseType(typeof(Catagory_tbl))]
        public IHttpActionResult GetCatagory_tbl(int id)
        {
            Catagory_tbl catagory_tbl = db.Catagory_tbl.Find(id);
            if (catagory_tbl == null)
            {
                return NotFound();
            }

            return Ok(catagory_tbl);
        }

        // PUT: api/Catagory_tbl/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCatagory_tbl(int id, Catagory_tbl catagory_tbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catagory_tbl.CatagoryCode)
            {
                return BadRequest();
            }

            db.Entry(catagory_tbl).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Catagory_tblExists(id))
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

        // POST: api/Catagory_tbl
        [ResponseType(typeof(Catagory_tbl))]
        public IHttpActionResult PostCatagory_tbl(Catagory_tbl catagory_tbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Catagory_tbl.Add(catagory_tbl);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = catagory_tbl.CatagoryCode }, catagory_tbl);
        }

        // DELETE: api/Catagory_tbl/5
        [ResponseType(typeof(Catagory_tbl))]
        public IHttpActionResult DeleteCatagory_tbl(int id)
        {
            Catagory_tbl catagory_tbl = db.Catagory_tbl.Find(id);
            if (catagory_tbl == null)
            {
                return NotFound();
            }

            db.Catagory_tbl.Remove(catagory_tbl);
            db.SaveChanges();

            return Ok(catagory_tbl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Catagory_tblExists(int id)
        {
            return db.Catagory_tbl.Count(e => e.CatagoryCode == id) > 0;
        }
    }
}
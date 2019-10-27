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
    public class Symbols_tblController : ApiController
    {
        private symbolsEntities1 db = new symbolsEntities1();

        // GET: api/Symbols_tbl
        public IQueryable<Symbols_tbl> GetSymbols_tbl()
        {
            return db.Symbols_tbl;
        }

        // GET: api/Symbols_tbl/5
        [ResponseType(typeof(Symbols_tbl))]
        public IHttpActionResult GetSymbols_tbl(int id)
        {
            Symbols_tbl symbols_tbl = db.Symbols_tbl.Find(id);
            if (symbols_tbl == null)
            {
                return NotFound();
            }

            return Ok(symbols_tbl);
        }

        // PUT: api/Symbols_tbl/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSymbols_tbl(int id, Symbols_tbl symbols_tbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != symbols_tbl.SymbolCode)
            {
                return BadRequest();
            }

            db.Entry(symbols_tbl).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Symbols_tblExists(id))
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

        // POST: api/Symbols_tbl
        [ResponseType(typeof(Symbols_tbl))]
        public IHttpActionResult PostSymbols_tbl(Symbols_tbl symbols_tbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Symbols_tbl.Add(symbols_tbl);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = symbols_tbl.SymbolCode }, symbols_tbl);
        }

        // DELETE: api/Symbols_tbl/5
        [ResponseType(typeof(Symbols_tbl))]
        public IHttpActionResult DeleteSymbols_tbl(int id)
        {
            Symbols_tbl symbols_tbl = db.Symbols_tbl.Find(id);
            if (symbols_tbl == null)
            {
                return NotFound();
            }

            db.Symbols_tbl.Remove(symbols_tbl);
            db.SaveChanges();

            return Ok(symbols_tbl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Symbols_tblExists(int id)
        {
            return db.Symbols_tbl.Count(e => e.SymbolCode == id) > 0;
        }
    }
}
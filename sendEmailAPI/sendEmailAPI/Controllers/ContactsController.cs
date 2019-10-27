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
    public class ContactsController : ApiController
    {
        private symbolsEntities1 db = new symbolsEntities1();

        // GET: api/Contacts
        public IQueryable<Contacts_tbl> GetContacts()
        {
            return db.Contacts_tbl;
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(Contacts_tbl))]
        public IHttpActionResult GetContact(int id)
        {
            Contacts_tbl contact = db.Contacts_tbl.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contacts_tbl contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Code)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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

        // POST: api/Contacts
        [ResponseType(typeof(Contacts_tbl))]
        public IHttpActionResult PostContact(Contacts_tbl contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contacts_tbl.Add(contact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contact.Code }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contacts_tbl))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contacts_tbl contact = db.Contacts_tbl.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts_tbl.Remove(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contacts_tbl.Count(e => e.Code == id) > 0;
        }
    }
}
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
    public class MessagesController : ApiController
    {
        private symbolsEntities1 db = new symbolsEntities1();

        // GET: api/Messages
        public IQueryable<Message_tbl> GetMessages()
        {
            return db.Message_tbl;
        }

        // GET: api/Messages/5
        [ResponseType(typeof(Message_tbl))]
        public IHttpActionResult GetMessage(int id)
        {
            Message_tbl message = db.Message_tbl.Find(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // PUT: api/Messages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMessage(int id, Message_tbl message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.MessageId)
            {
                return BadRequest();
            }

            db.Entry(message).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        // POST: api/Messages
        [ResponseType(typeof(Message_tbl))]
        public IHttpActionResult PostMessage(Message_tbl message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Message_tbl.Add(message);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = message.MessageId }, message);
        }

        // DELETE: api/Messages/5
        [ResponseType(typeof(Message_tbl))]
        public IHttpActionResult DeleteMessage(int id)
        {
            Message_tbl message = db.Message_tbl.Find(id);
            if (message == null)
            {
                return NotFound();
            }
            db.SaveChanges();

            return Ok(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessageExists(int id)
        {
            return db.Message_tbl.Count(e => e.MessageId == id) > 0;
        }
    }
}
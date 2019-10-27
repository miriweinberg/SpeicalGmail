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
    public class UsersController : ApiController
    {
        private symbolsEntities1 db = new symbolsEntities1();

        // GET: api/Users
        public List<Users_tbl> GetUsers()
        {
            List<Users_tbl> allUsers= new List<Users_tbl>();
            foreach (var item in db.Users_tbl)
            {
                allUsers.Add(item);
            }
           
            return allUsers;
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users_tbl))]
        public IHttpActionResult GetUser(string id)
        {
            Users_tbl user = db.Users_tbl.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //// PUT: api/Users/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUser(string id, User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != user.Password)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Users
        [ResponseType(typeof(Users_tbl))]
        public IHttpActionResult PostUser(Users_tbl user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users_tbl.Add(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Password))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user.Password }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users_tbl))]
        public IHttpActionResult DeleteUser(string id)
        {
            Users_tbl user = db.Users_tbl.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users_tbl.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(string id)
        {
            return db.Users_tbl.Count(e => e.Password == id) > 0;
        }
    }
}
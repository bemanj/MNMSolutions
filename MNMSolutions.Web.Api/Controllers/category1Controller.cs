using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.Web.Api.Controllers
{
    public class Category1Controller : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/category1
        public IQueryable<category1> Getcategories1()
        {
            return _db.categories1;
        }

        // GET: api/category1/5
        [ResponseType(typeof(category1))]
        public async Task<IHttpActionResult> Getcategory1(string id)
        {
            category1 category1 = await _db.categories1.FindAsync(id);
            if (category1 == null)
            {
                return NotFound();
            }

            return Ok(category1);
        }

        // PUT: api/category1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcategory1(string id, category1 category1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category1.category)
            {
                return BadRequest();
            }

            _db.Entry(category1).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!category1Exists(id))
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

        // POST: api/category1
        [ResponseType(typeof(category1))]
        public async Task<IHttpActionResult> Postcategory1(category1 category1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.categories1.Add(category1);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (category1Exists(category1.category))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = category1.category }, category1);
        }

        // DELETE: api/category1/5
        [ResponseType(typeof(category1))]
        public async Task<IHttpActionResult> Deletecategory1(string id)
        {
            category1 category1 = await _db.categories1.FindAsync(id);
            if (category1 == null)
            {
                return NotFound();
            }

            _db.categories1.Remove(category1);
            await _db.SaveChangesAsync();

            return Ok(category1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool category1Exists(string id)
        {
            return _db.categories1.Count(e => e.category == id) > 0;
        }
    }
}
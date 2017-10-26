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

namespace MNMSolutions.Web.Api.Controllers.Inventory
{
    public class CategoryOnesController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/CategoryOnes
        public IQueryable<CategoryOne> GetCategoryOnes()
        {
            return _db.CategoryOnes;
        }

        // GET: api/CategoryOnes/5
        [ResponseType(typeof(CategoryOne))]
        public async Task<IHttpActionResult> GetCategoryOne(int id)
        {
            CategoryOne categoryOne = await _db.CategoryOnes.FindAsync(id);
            if (categoryOne == null)
            {
                return NotFound();
            }

            return Ok(categoryOne);
        }

        // PUT: api/CategoryOnes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategoryOne(int id, CategoryOne categoryOne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryOne.CategoryID)
            {
                return BadRequest();
            }

            _db.Entry(categoryOne).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryOneExists(id))
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

        // POST: api/CategoryOnes
        [ResponseType(typeof(CategoryOne))]
        public async Task<IHttpActionResult> PostCategoryOne(CategoryOne categoryOne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.CategoryOnes.Add(categoryOne);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categoryOne.CategoryID }, categoryOne);
        }

        // DELETE: api/CategoryOnes/5
        [ResponseType(typeof(CategoryOne))]
        public async Task<IHttpActionResult> DeleteCategoryOne(int id)
        {
            CategoryOne categoryOne = await _db.CategoryOnes.FindAsync(id);
            if (categoryOne == null)
            {
                return NotFound();
            }

            _db.CategoryOnes.Remove(categoryOne);
            await _db.SaveChangesAsync();

            return Ok(categoryOne);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryOneExists(int id)
        {
            return _db.CategoryOnes.Count(e => e.CategoryID == id) > 0;
        }
    }
}
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

namespace MNMSolutions.Web.Api.Controllers.Category
{
    public class View_CategoryController : ApiController
    {
        private MNMSolutionsDevDBEntities db = new MNMSolutionsDevDBEntities();

        // GET: api/View_Category
        public IQueryable<View_Category> GetView_Category()
        {
            return db.View_Category;
        }

        // GET: api/View_Category/5
        [ResponseType(typeof(View_Category))]
        public async Task<IHttpActionResult> GetView_Category(int id)
        {
            View_Category view_Category = await db.View_Category.FindAsync(id);
            if (view_Category == null)
            {
                return NotFound();
            }

            return Ok(view_Category);
        }

        //// PUT: api/View_Category/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutView_Category(int id, View_Category view_Category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != view_Category.CategoryID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(view_Category).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!View_CategoryExists(id))
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

        //// POST: api/View_Category
        //[ResponseType(typeof(View_Category))]
        //public async Task<IHttpActionResult> PostView_Category(View_Category view_Category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.View_Category.Add(view_Category);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = view_Category.CategoryID }, view_Category);
        //}

        //// DELETE: api/View_Category/5
        //[ResponseType(typeof(View_Category))]
        //public async Task<IHttpActionResult> DeleteView_Category(int id)
        //{
        //    View_Category view_Category = await db.View_Category.FindAsync(id);
        //    if (view_Category == null)
        //    {
        //        return NotFound();
        //    }

        //    db.View_Category.Remove(view_Category);
        //    await db.SaveChangesAsync();

        //    return Ok(view_Category);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool View_CategoryExists(int id)
        //{
        //    return db.View_Category.Count(e => e.CategoryID == id) > 0;
        //}
    }
}
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
using MNMSolutions.DAL.Repository;

namespace MNMSolutions.Web.Api.Controllers
{
    public class Category1Controller : ApiController
    {
        //private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        #region Global Declaration
        private IRepository<category1> _Category1repository = null;

        public Category1Controller()
        {
            this._Category1repository = new Repository<category1>();
        }
        #endregion

        // GET: api/category1
        //[Route("api/category1")]
        [HttpGet]
        public HttpResponseMessage Getcategories1()
        {
            var result = _Category1repository.GetAll();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        // GET: api/category1/5
        [ResponseType(typeof(category1))]
        public IHttpActionResult Getcategories1(string id)
        {
            //var result = _Category1repository.GetById(id);
            category1 category1 = _Category1repository.GetById(id);//_db.categories1.FindAsync(id);
            if (category1 == null)
            {
                return NotFound();
            }

            return Ok(category1);
        }

        //// PUT: api/category1/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> Putcategory1(string id, category1 category1)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != category1.category)
        //    {
        //        return BadRequest();
        //    }

        //    _db.Entry(category1).State = EntityState.Modified;

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!category1Exists(id))
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

        //// POST: api/category1
        //[ResponseType(typeof(category1))]
        //public async Task<IHttpActionResult> Postcategory1(category1 category1)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.categories1.Add(category1);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (category1Exists(category1.category))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = category1.category }, category1);
        //}

        //// DELETE: api/category1/5
        //[ResponseType(typeof(category1))]
        //public async Task<IHttpActionResult> Deletecategory1(string id)
        //{
        //    category1 category1 = await _db.categories1.FindAsync(id);
        //    if (category1 == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.categories1.Remove(category1);
        //    await _db.SaveChangesAsync();

        //    return Ok(category1);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool category1Exists(string id)
        //{
        //    return _db.categories1.Count(e => e.category == id) > 0;
        //}
    }
}
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
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.Web.Api.Controllers.Product
{
    public class ViewProductController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/View_Product
        public IQueryable<View_Product> GetView_Product()
        {
            return _db.View_Product;
        }

        // GET: api/View_Product/5
        [ResponseType(typeof(View_Product))]
        public IHttpActionResult GetView_Product(int id)
        {
            View_Product viewProduct = _db.View_Product.Find(id);
            if (viewProduct == null)
            {
                return NotFound();
            }

            return Ok(viewProduct);
        }

        //// PUT: api/View_Product/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutView_Product(int id, View_Product view_Product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != view_Product.ProductId)
        //    {
        //        return BadRequest();
        //    }

        //    _db.Entry(view_Product).State = EntityState.Modified;

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!View_ProductExists(id))
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

        //// POST: api/View_Product
        //[ResponseType(typeof(View_Product))]
        //public IHttpActionResult PostView_Product(View_Product view_Product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.View_Product.Add(view_Product);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (View_ProductExists(view_Product.ProductId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = view_Product.ProductId }, view_Product);
        //}

        //// DELETE: api/View_Product/5
        //[ResponseType(typeof(View_Product))]
        //public IHttpActionResult DeleteView_Product(int id)
        //{
        //    View_Product view_Product = _db.View_Product.Find(id);
        //    if (view_Product == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.View_Product.Remove(view_Product);
        //    _db.SaveChanges();

        //    return Ok(view_Product);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool View_ProductExists(int id)
        //{
        //    return _db.View_Product.Count(e => e.ProductId == id) > 0;
        //}
    }
}
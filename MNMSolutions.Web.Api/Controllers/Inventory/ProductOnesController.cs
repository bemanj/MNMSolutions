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
using MNMSolutions.DAL.Models.Product;

namespace MNMSolutions.Web.Api.Controllers.Inventory
{
    public class ProductOnesController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/ProductOnes
        public IQueryable<ProductOne> GetProductOnes()
        {
            return _db.ProductOnes;
        }

        // GET: api/ProductOnes/5
        [ResponseType(typeof(ProductOne))]
        public async Task<IHttpActionResult> GetProductOne(int id)
        {
            ProductOne productOne = await _db.ProductOnes.FindAsync(id);
            if (productOne == null)
            {
                return NotFound();
            }

            return Ok(productOne);
        }

        // PUT: api/ProductOnes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductOne(int id, ProductOne productOne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productOne.ProductId)
            {
                return BadRequest();
            }

            _db.Entry(productOne).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOneExists(id))
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

        // POST: api/ProductOnes
        public IEnumerable<vsp_Product_CreateThenReturn_Result> PostProductOne(NewProduct newproduct)
        {
            try
            {
                var product = _db.vsp_Product_CreateThenReturn(newproduct.CategoryId, newproduct.ProductTitle, newproduct.ReorderLevel);

                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        // POST: api/ProductOnes
        //[ResponseType(typeof(ProductOne))]
        //public async Task<IHttpActionResult> PostProductOne(ProductOne productOne)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.ProductOnes.Add(productOne);
        //    await _db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = productOne.ProductId }, productOne);
        //}

        // DELETE: api/ProductOnes/5
        [ResponseType(typeof(ProductOne))]
        public async Task<IHttpActionResult> DeleteProductOne(int id)
        {
            ProductOne productOne = await _db.ProductOnes.FindAsync(id);
            if (productOne == null)
            {
                return NotFound();
            }

            _db.ProductOnes.Remove(productOne);
            await _db.SaveChangesAsync();

            return Ok(productOne);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductOneExists(int id)
        {
            return _db.ProductOnes.Count(e => e.ProductId == id) > 0;
        }
    }
}
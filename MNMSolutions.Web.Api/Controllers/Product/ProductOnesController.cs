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

namespace MNMSolutions.Web.Api.Controllers.Product
{
    public class ProductOnesController : ApiController
    {
        private MNMSolutionsDevDBEntities db = new MNMSolutionsDevDBEntities();

        // GET: api/ProductOnes
        public IQueryable<ProductOne> GetProductOnes()
        {
            return db.ProductOnes;
        }

        // GET: api/ProductOnes/5
        [ResponseType(typeof(ProductOne))]
        public async Task<IHttpActionResult> GetProductOne(int id)
        {
            ProductOne productOne = await db.ProductOnes.FindAsync(id);
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

            db.Entry(productOne).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
        [ResponseType(typeof(ProductOne))]
        public async Task<IHttpActionResult> PostProductOne(ProductOne productOne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductOnes.Add(productOne);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productOne.ProductId }, productOne);
        }

        // DELETE: api/ProductOnes/5
        [ResponseType(typeof(ProductOne))]
        public async Task<IHttpActionResult> DeleteProductOne(int id)
        {
            ProductOne productOne = await db.ProductOnes.FindAsync(id);
            if (productOne == null)
            {
                return NotFound();
            }

            db.ProductOnes.Remove(productOne);
            await db.SaveChangesAsync();

            return Ok(productOne);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductOneExists(int id)
        {
            return db.ProductOnes.Count(e => e.ProductId == id) > 0;
        }
    }
}
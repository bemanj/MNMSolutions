using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MNMSolutions.DAL.DB.Dev;
using MNMSolutions.DAL.BLL.Product;

namespace MNMSolutions.Web.Api.Controllers.Product
{
    public class ProductListController : ApiController
    {
        private MNMSolutionsDevDBEntities db = new MNMSolutionsDevDBEntities();
        private ProductList plist = new ProductList();

        // GET: api/ProductList
        public IQueryable<ProductOne> GetProductOnes() => plist.ReturnTaxFreeProductList();

        // GET: api/ProductList/5
        [ResponseType(typeof(ProductOne))]
        public IHttpActionResult GetProductOne(int id)
        {
            ProductOne productOne = db.ProductOnes.Find(id);
            if (productOne == null)
            {
                return NotFound();
            }

            return Ok(productOne);
        }

        // PUT: api/ProductList/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductOne(int id, ProductOne productOne)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != productOne.ProductId)
            //{
            //    return BadRequest();
            //}

            //db.Entry(productOne).State = EntityState.Modified;

            try
            {
                plist.UpdateProduct(id, productOne);
                //db.SaveChanges();
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

        // POST: api/ProductList
        [ResponseType(typeof(ProductOne))]
        public IHttpActionResult PostProductOne(ProductOne productOne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductOnes.Add(productOne);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productOne.ProductId }, productOne);
        }

        // DELETE: api/ProductList/5
        [ResponseType(typeof(ProductOne))]
        public IHttpActionResult DeleteProductOne(int id)
        {
            ProductOne productOne = db.ProductOnes.Find(id);
            if (productOne == null)
            {
                return NotFound();
            }

            db.ProductOnes.Remove(productOne);
            db.SaveChanges();

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
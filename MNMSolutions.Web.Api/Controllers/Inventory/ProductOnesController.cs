using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using MNMSolutions.DAL.DB.Dev;
using MNMSolutions.DAL.Models;
using MNMSolutions.DAL.Models.Customer;

namespace MNMSolutions.Web.Api.Controllers.Inventory
{
    public class ProductOnesController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/ProductOnes
        public IQueryable<View_Product> GetProductOnes()
        {
            return _db.View_Product;
        }

        // GET: api/ProductOnes/5
        public IEnumerable<vsp_Product_ViewByProductId_Result> Getinventory_view(int id)
        {
            var productList = _db.vsp_Product_ViewByProductId(id).AsEnumerable();

            

            return productList;
        }

        // PUT: api/ProductOnes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductOne(int id, UpdateProduct p)
        {
           if (id != p.ProductId)
            {
                return BadRequest();
            }

            try
            {
                _db.vsp_Product_UpdateById(p.CategoryId, p.ProductTitle, p.ReorderLevel, p.Discontinued, p.ProductId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Debug.Assert(e.InnerException != null, "e.InnerException != null");
                throw e.InnerException;
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
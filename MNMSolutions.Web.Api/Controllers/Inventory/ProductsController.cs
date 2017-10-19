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
using MNMSolutions.DAL.DB.Models;

namespace MNMSolutions.Web.Api.Controllers.Inventory
{
    public class ProductsController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();
        //private IQueryable<Product> productlist;

        // GET: api/Products
        public List<ProductList> GetProducts()
        {
            var plist = _db.Products
                .Select(p => new ProductList()
                    {
                        ProductId = p.ProductID,
                        ProductName = p.ProductName,
                        Category = p.Category.CategoryName,
                        QuantityPerUnit = p.QuantityPerUnit,
                        UnitsInStock = p.UnitsInStock,
                        UnitPrice = p.UnitPrice
                    });

            return plist.ToList();

        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return _db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}
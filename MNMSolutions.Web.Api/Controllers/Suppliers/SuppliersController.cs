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
using MNMSolutions.DAL.BLL.Product;

namespace MNMSolutions.Web.Api.Controllers.Suppliers
{
    public class SuppliersController : ApiController
    {
        private SupplierFunction supplierFunction = new SupplierFunction();
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/Suppliers
        public IQueryable<Supplier> GetSuppliers()
        {
            return _db.Suppliers;
        }

        // GET: api/Suppliers/5
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult GetSupplier(int id)
        {
            Supplier supplier = _db.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        // PUT: api/Suppliers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupplier(int id, Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplier.SupplierID)
            {
                return BadRequest();
            }

            //_db.Entry(supplier).State = EntityState.Modified;

            try
            {
                supplierFunction.UpdateSupplier(id, supplier);
                //_db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
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

        // POST: api/Suppliers
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult PostSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Suppliers.Add(supplier);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = supplier.SupplierID }, supplier);
        }

        // DELETE: api/Suppliers/5
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult DeleteSupplier(int id)
        {
            Supplier supplier = _db.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _db.Suppliers.Remove(supplier);
            _db.SaveChanges();

            return Ok(supplier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierExists(int id)
        {
            return _db.Suppliers.Count(e => e.SupplierID == id) > 0;
        }
    }
}
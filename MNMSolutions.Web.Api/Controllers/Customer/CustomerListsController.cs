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

namespace MNMSolutions.Web.Api.Controllers.Customer
{
    public class CustomerListsController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/CustomerLists
        public IQueryable<CustomerList> GetCustomerLists()
        {
            return _db.CustomerLists;
        }

        // GET: api/CustomerLists/5
        [ResponseType(typeof(CustomerList))]
        public IHttpActionResult GetCustomerList(int id)
        {
            CustomerList customerList = _db.CustomerLists.Find(id);
            if (customerList == null)
            {
                return NotFound();
            }

            return Ok(customerList);
        }

        // PUT: api/CustomerLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerList(int id, CustomerList customerList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerList.CustomerID)
            {
                return BadRequest();
            }

            _db.Entry(customerList).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerListExists(id))
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

        // POST: api/CustomerLists
        [ResponseType(typeof(CustomerList))]
        public IHttpActionResult PostCustomerList(CustomerList customerList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.CustomerLists.Add(customerList);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerList.CustomerID }, customerList);
        }

        // DELETE: api/CustomerLists/5
        [ResponseType(typeof(CustomerList))]
        public IHttpActionResult DeleteCustomerList(int id)
        {
            CustomerList customerList = _db.CustomerLists.Find(id);
            if (customerList == null)
            {
                return NotFound();
            }

            _db.CustomerLists.Remove(customerList);
            _db.SaveChanges();

            return Ok(customerList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerListExists(int id)
        {
            return _db.CustomerLists.Count(e => e.CustomerID == id) > 0;
        }
    }
}
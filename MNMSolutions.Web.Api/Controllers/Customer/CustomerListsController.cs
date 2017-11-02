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
using MNMSolutions.DAL.Models.Customer;

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
        [ResponseType(typeof(NewCustomer))]
        public IHttpActionResult PostCustomerList(NewCustomer c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _db.vsp_Customer_Create(c.CompanyName, c.ContactName, c.ContactTitle, c.Address, c.City, c.Region,
                    c.PostalCode, c.Country, c.Phone, c.Fax, c.Terms);

                return StatusCode(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return StatusCode(HttpStatusCode.ExpectationFailed);
            }
            
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
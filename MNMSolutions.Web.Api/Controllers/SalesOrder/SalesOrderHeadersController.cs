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

namespace MNMSolutions.Web.Api.Controllers.SalesOrder
{
    public class SalesOrderHeadersController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/SalesOrderHeaders
        public IQueryable<SalesOrderHeader> GetSalesOrderHeaders()
        {
            return _db.SalesOrderHeaders;
        }

        // GET: api/SalesOrderHeaders/5
        [ResponseType(typeof(SalesOrderHeader))]
        public IHttpActionResult GetSalesOrderHeader(int id)
        {
            SalesOrderHeader salesOrderHeader = _db.SalesOrderHeaders.Find(id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            return Ok(salesOrderHeader);
        }

        // PUT: api/SalesOrderHeaders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalesOrderHeader(int id, SalesOrderHeader salesOrderHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesOrderHeader.SalesOrderID)
            {
                return BadRequest();
            }

            _db.Entry(salesOrderHeader).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderHeaderExists(id))
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

        // POST: api/SalesOrderHeaders
        [ResponseType(typeof(SalesOrderHeader))]
        public IHttpActionResult PostSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.SalesOrderHeaders.Add(salesOrderHeader);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = salesOrderHeader.SalesOrderID }, salesOrderHeader);
        }

        // DELETE: api/SalesOrderHeaders/5
        [ResponseType(typeof(SalesOrderHeader))]
        public IHttpActionResult DeleteSalesOrderHeader(int id)
        {
            SalesOrderHeader salesOrderHeader = _db.SalesOrderHeaders.Find(id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            _db.SalesOrderHeaders.Remove(salesOrderHeader);
            _db.SaveChanges();

            return Ok(salesOrderHeader);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesOrderHeaderExists(int id)
        {
            return _db.SalesOrderHeaders.Count(e => e.SalesOrderID == id) > 0;
        }
    }
}
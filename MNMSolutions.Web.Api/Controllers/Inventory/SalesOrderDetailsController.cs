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

namespace MNMSolutions.Web.Api.Controllers.Inventory
{
    public class SalesOrderDetailsController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/SalesOrderDetails
        public IQueryable<SalesOrderDetail> GetSalesOrderDetails()
        {
            return _db.SalesOrderDetails;
        }

        // GET: api/SalesOrderDetails/5
        [ResponseType(typeof(SalesOrderDetail))]
        public async Task<IHttpActionResult> GetSalesOrderDetail(int id)
        {
            SalesOrderDetail salesOrderDetail = await _db.SalesOrderDetails.FindAsync(id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            return Ok(salesOrderDetail);
        }

        // PUT: api/SalesOrderDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSalesOrderDetail(int id, SalesOrderDetail salesOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesOrderDetail.SalesOrderID)
            {
                return BadRequest();
            }

            _db.Entry(salesOrderDetail).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderDetailExists(id))
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

        // POST: api/SalesOrderDetails
        [ResponseType(typeof(SalesOrderDetail))]
        public async Task<IHttpActionResult> PostSalesOrderDetail(SalesOrderDetail salesOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.SalesOrderDetails.Add(salesOrderDetail);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = salesOrderDetail.SalesOrderID }, salesOrderDetail);
        }

        // DELETE: api/SalesOrderDetails/5
        [ResponseType(typeof(SalesOrderDetail))]
        public async Task<IHttpActionResult> DeleteSalesOrderDetail(int id)
        {
            SalesOrderDetail salesOrderDetail = await _db.SalesOrderDetails.FindAsync(id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            _db.SalesOrderDetails.Remove(salesOrderDetail);
            await _db.SaveChangesAsync();

            return Ok(salesOrderDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesOrderDetailExists(int id)
        {
            return _db.SalesOrderDetails.Count(e => e.SalesOrderID == id) > 0;
        }
    }
}
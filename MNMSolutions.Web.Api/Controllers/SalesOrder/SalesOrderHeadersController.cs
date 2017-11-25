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
using MNMSolutions.DAL.BLL.Sales;
using MNMSolutions.DAL.Models.Sales.Order;

namespace MNMSolutions.Web.Api.Controllers.SalesOrder
{
    public class SalesOrderHeadersController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();
        private OrderHeaderFunctions _orderHeaderF = new OrderHeaderFunctions();

        // GET: api/SalesOrderHeaders
        public IEnumerable<vsp_SOH_NotFulfilled_OrderBy_SOID_Desc_Result> GetSalesOrderHeaders()
        {
            return _db.vsp_SOH_NotFulfilled_OrderBy_SOID_Desc();
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


        // POST: api/ProductOnes
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalesOrderHeader(int id, SalesOrderHeader _s)
        {
            try
            {
                //_db.usp_SOH_Update(orderHeader.SalesOrderId, orderHeader.Customer, orderHeader.OnlineOrderFlag, 0, 0, 0, orderHeader.Comment, orderHeader.Fulfilled, orderHeader.ComputeTax);
                _orderHeaderF.UpdateSalesOrder(id, _s);

                _db.vsp_orderHeader_UpdateSubTotal_ViewBySOId(_s.SalesOrderID);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        // PUT: api/SalesOrderHeaders/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutSalesOrderHeader(int id, SalesOrderHeader salesOrderHeader)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != salesOrderHeader.SalesOrderID)
        //    {
        //        return BadRequest();
        //    }

        //    _db.Entry(salesOrderHeader).State = EntityState.Modified;

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SalesOrderHeaderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/SalesOrderHeaders
        [ResponseType(typeof(SalesOrderHeader))]
        public IHttpActionResult PostSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_db.SalesOrderHeaders.Add(salesOrderHeader);
            //_db.SaveChanges();

            var newso = _orderHeaderF.CreateSalesOrder(salesOrderHeader);

            return CreatedAtRoute("DefaultApi", new { id = newso.SalesOrderID }, newso);
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
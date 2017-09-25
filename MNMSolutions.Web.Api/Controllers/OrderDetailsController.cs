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
using MNMSolutions.DAL.DB.Test;

namespace MNMSolutions.Web.Api.Controllers
{
    public class OrderDetailsController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/OrderDetails
        public IQueryable<OrderDetailList> GetOrderDetails()
        {
            var orderList = _db.OrderDetails
                .Select(o => new OrderDetailList()
                {
                    OrderId = o.OrderID,
                    UnitPrice = o.UnitPrice,
                    Quantity = o.Quantity,
                    Discount = o.Discount,
                    TotalAmount = o.TotalAmount
                });
            return orderList;
        }

        // GET: api/OrderDetails/5
        [ResponseType(typeof(OrderDetail))]
        public async Task<IHttpActionResult> GetOrderDetail(int id)
        {
            OrderDetail orderDetail = await _db.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
        }

        // PUT: api/OrderDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderDetail.OrderID)
            {
                return BadRequest();
            }

            _db.Entry(orderDetail).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(orderDetail.OrderID, orderDetail.ProductID))
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

        // POST: api/OrderDetails
        [ResponseType(typeof(OrderDetail))]
        public async Task<IHttpActionResult> PostOrderDetail(OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.OrderDetails.Add(orderDetail);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderDetailExists(orderDetail.OrderID, orderDetail.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orderDetail.OrderID }, orderDetail);
        }

        // DELETE: api/OrderDetails/5
        [ResponseType(typeof(OrderDetail))]
        public async Task<IHttpActionResult> DeleteOrderDetail(int id)
        {
            OrderDetail orderDetail = await _db.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _db.OrderDetails.Remove(orderDetail);
            await _db.SaveChangesAsync();

            return Ok(orderDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderDetailExists(int id, int productId)
        {
            return _db.OrderDetails.Count(e => (e.OrderID == id && e.ProductID == productId) ) > 0;
        }
    }
}
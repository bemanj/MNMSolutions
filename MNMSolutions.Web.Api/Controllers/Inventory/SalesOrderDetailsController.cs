using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MNMSolutions.DAL.DB.Dev;
using MNMSolutions.DAL.Models.Sales.Order;


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
        public  IEnumerable<vsp_orderdetail_ViewBySalesOrderId_Result> GetSalesOrderDetail(int id)
        {
            return _db.vsp_orderdetail_ViewBySalesOrderId(id).AsEnumerable();
        }

        // PUT: api/SalesOrderDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalesOrderDetail(int id, OrderDetail soDetail)
        {
            try
            {
                _db.usp_SOD_Update(soDetail.SalesDetailsId, soDetail.Discount, soDetail.TotalAmount);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

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

            _db.vsp_orderHeader_UpdateSubTotal_ViewBySOId(salesOrderDetail.SalesOrderID);

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

    }
}
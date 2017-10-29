using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.MMSolution.Core.Domain;
using WebAPI.MMSolution.Models;
using WebAPI.MMSolution.Persistence;

namespace WebAPI.MMSolution.Controllers
{
    public class OrderDetailController : ApiController
    {
        // GET: api/OrderDetail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OrderDetail/5
        [ResponseType(typeof(OrderDetails))]
        public IHttpActionResult GetOrderDetails(int OrderID, int ProductID)
        {
            using (var _unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                var _OrderDetails = _unitofWork.OrderDetails.GetByOrderIDProductID(OrderID, ProductID);
                return Ok(_OrderDetails);
            }
        }
        //POST: api/Insert/Ord
        //POST: api/Insert/OrderDetail
        [ResponseType(typeof(OrderDetails))]
        public IHttpActionResult PostOrderDetails(OrderDetails order)
        {
            using (var _unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                _unitofWork.OrderDetails.Insert(order);
                _unitofWork.Dispose();
                return Ok(order);

            }
        }

        // PUT: api/OrderDetail/5
        [ResponseType(typeof(OrderDetails))]
        public IHttpActionResult PutOrderDetails(OrderDetails order)
        {
            using (var _unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                _unitofWork.OrderDetails.Update(order);
                _unitofWork.Dispose();
                return Ok(order);

            }
        }

        // DELETE: api/OrderDetail/5
        [ResponseType(typeof(OrderDetails))]
        public IHttpActionResult Delete(int OrderID, int ProductID)
        {
            using (var _unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                _unitofWork.OrderDetails.Delete(OrderID,ProductID);
                _unitofWork.Dispose();
                return Ok();

            }
        }
    }
}

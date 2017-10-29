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
    public class SalesOrderDetailsController : ApiController
    {
        // GET: api/SalesOrderDetails
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SalesOrderDetails/5
        [ResponseType(typeof(SalesOrderDetails))]
        public IHttpActionResult GetSalesOrderDetails(int SODetailsID)
        {
            using (var _unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                var _SalesOrderDetails = _unitofWork.SalesOrderDetails.GetSalesOrderDetailByID(SODetailsID);
                return Ok(_SalesOrderDetails);
            }
        }

        // POST: api/SalesOrderDetails
        [ResponseType(typeof(SalesOrderDetails))]
        public IHttpActionResult PostSalesOrderDetails(SalesOrderDetails d)
        {
            using (var _unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                _unitofWork.SalesOrderDetails.Insert(d);
                _unitofWork.Dispose();
                return Ok(d);

            }
        }

        // PUT: api/SalesOrderDetails/5
        [ResponseType(typeof(SalesOrderDetails))]
        public IHttpActionResult PutSalesOrderDetails(SalesOrderDetails d)
        {
            using (var _unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                _unitofWork.SalesOrderDetails.Update(d);
                _unitofWork.Dispose();
                return Ok(d);

            }
        }

        // DELETE: api/SalesOrderDetails/5
        [ResponseType(typeof(SalesOrderDetails))]
        public IHttpActionResult DeleteSalesOrderDetails(int SODetailsID)
        {
            using (var _unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                _unitofWork.SalesOrderDetails.Delete(SODetailsID);
                _unitofWork.Dispose();
                return Ok();

            }
        }
    }
}

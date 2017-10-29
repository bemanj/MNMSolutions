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
    public class SalesOrderHeaderController : ApiController
    {
        // GET: api/SalesOrderHeader
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SalesOrderHeader/5
        [ResponseType(typeof(SalesOrderHeaders))]
        public IHttpActionResult GetSalesOrderHeaderDetails(int SOHeaderID)
        {
            using (var _unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                var _SalesOrderHeader = _unitofWork.SalesOrderHeader.GetBSalesOrderHeaderID(SOHeaderID);
                return Ok(_SalesOrderHeader);
            }
        }

        // POST: api/SalesOrderHeader
        [ResponseType(typeof(SalesOrderHeaders))]
        public IHttpActionResult PostSalesOrderHeader(SalesOrderHeaders d)
        {
            using (var _unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                _unitofWork.SalesOrderHeader.Insert(d);
                _unitofWork.Dispose();
                return Ok(d);

            }
        }
        // PUT: api/SalesOrderHeader/5
        [ResponseType(typeof(SalesOrderHeaders))]
        public IHttpActionResult PutSalesOrderHeader(SalesOrderHeaders d)
        {
            using (var _unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                _unitofWork.SalesOrderHeader.Update(d);
                _unitofWork.Dispose();
                return Ok(d);

            }
        }

        // DELETE: api/SalesOrderHeader/5
        [ResponseType(typeof(SalesOrderHeaders))]
        public IHttpActionResult DeleteSalesOrderHeader(int SOHeaderID)
        {
            using (var _unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                _unitofWork.SalesOrderHeader.Delete(SOHeaderID);
                _unitofWork.Dispose();
                return Ok();

            }
        }
    }
}

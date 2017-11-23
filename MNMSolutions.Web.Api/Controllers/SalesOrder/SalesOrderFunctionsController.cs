using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MNMSolutions.DAL.BLL.Sales;

namespace MNMSolutions.Web.Api.Controllers.SalesOrder
{
    public class SalesOrderFunctionsController : ApiController
    {
        private OrderHeaderFunctions _orderHeaderF = new OrderHeaderFunctions();

        // POST: api/SalesOrderFunctions
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompleteSalesOrder(int id)
        {
            try
            {
                _orderHeaderF.CompleteOrder(id);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}

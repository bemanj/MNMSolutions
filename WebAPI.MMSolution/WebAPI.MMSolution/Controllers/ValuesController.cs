using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.MMSolution.Core.Domain;
using WebAPI.MMSolution.Models;
using WebAPI.MMSolution.Persistence;

namespace WebAPI.MMSolution.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            using (var unitofWork = new UnitOfWork(new MNMSolutionsDevDBEntities()))
            {
                OrderDetails d = new OrderDetails();
                d.OrderID = 1;
                d.ProductID = 1;
                d.UnitPrice = Convert.ToDecimal(1.50);
                d.Quantity = 1;
                d.Discount = Convert.ToInt64(0.50);
                d.TotalAmount = Convert.ToDecimal(1.50);


                unitofWork.OrderDetails.Insert(d);

            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

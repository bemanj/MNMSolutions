using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.Web.Api.Controllers.Inventory
{
    public class SpOrderHeaderController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/inventory_view
        public IEnumerable<sp_orderHeader_Result> Getinventory_view(int id)
        {
            var record = _db.sp_orderHeader(id).AsEnumerable();

            try
            {
                    return record;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                var notFoundResponse = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(notFoundResponse);
                
            }
            
        }
    }
}

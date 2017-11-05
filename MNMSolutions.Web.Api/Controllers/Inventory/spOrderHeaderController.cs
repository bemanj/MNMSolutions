using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MNMSolutions.DAL.DB.Dev;
using System.Web.Http.Description;

namespace MNMSolutions.Web.Api.Controllers.Inventory
{
    public class SpOrderHeaderController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/SalesOrderDetails/5
        //[ResponseType(typeof(View_SalesOrderDetails))]
        //public IHttpActionResult Getinventory_view(int id)
        //{
        //    var data = _db.sp_orderHeader(id);
        //    if (data == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(data);
        //}

        //GET: api/inventory_view
        //public IEnumerable<sp_orderHeader_Result> Getinventory_view(int id)
        //{
        //    //var data = _db.sp_orderHeader(id);

        //    var record = _db.sp_orderHeader(id).AsEnumerable();

        //    try
        //    {
        //            return record;
                
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        var notFoundResponse = new HttpResponseMessage(HttpStatusCode.NotFound);
        //        throw new HttpResponseException(notFoundResponse);

        //    }

        //}
    }
}

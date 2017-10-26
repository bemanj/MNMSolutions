using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MNMSolutions.DAL.DB.Dev;
using MNMSolutions.DAL.DB.Models;

namespace MNMSolutions.Web.Api.Controllers
{
    public class SalesReportController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/Products/5
        //[ResponseType(typeof())]
        [HttpGet]
        public ObjectResult<decimal?> GetTotalSales()
        {
            var totalSales = _db.sp_totalSalesForTheDay();

            return totalSales;
        }

    }
}

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
using MNMSolutions.DAL.DB.Models.SalesOrder;

namespace MNMSolutions.Web.Api.Controllers.Inventory
{
    public class InventoryViewController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/inventory_view
        public IQueryable<inventory_view> Getinventory_view()
        {
            return _db.inventory_view;
        }

        // GET: api/inventory_view
        public IEnumerable<vsp_orderdetail_ViewBySalesOrderId_Result> Getinventory_view(int id)
        {
            return _db.vsp_orderdetail_ViewBySalesOrderId(id).AsEnumerable();
        }

    }
}
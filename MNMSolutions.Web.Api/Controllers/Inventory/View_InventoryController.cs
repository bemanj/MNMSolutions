using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.Web.Api.Controllers.Inventory
{
    public class ViewInventoryController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/View_Inventory
        public IQueryable<View_Inventory> GetView_Inventory()
        {
            return _db.View_Inventory;
        }

        // GET: api/View_Inventory/5
        [ResponseType(typeof(View_Inventory))]
        public IHttpActionResult GetView_Inventory(int id)
        {
            View_Inventory viewInventory = _db.View_Inventory.Find(id);
            if (viewInventory == null)
            {
                return NotFound();
            }

            return Ok(viewInventory);
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
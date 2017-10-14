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
        public IEnumerable<sp_orderdetail_Result> Getinventory_view(int id)
        {
            return _db.sp_orderdetail(id).AsEnumerable();
        }

        // PUT: api/inventory_view/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putinventory_view(string id, inventory_view inventory_view)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventory_view.ProductName)
            {
                return BadRequest();
            }

            _db.Entry(inventory_view).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!inventory_viewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/inventory_view
        [ResponseType(typeof(inventory_view))]
        public async Task<IHttpActionResult> Postinventory_view(inventory_view inventory_view)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.inventory_view.Add(inventory_view);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (inventory_viewExists(inventory_view.ProductName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = inventory_view.ProductName }, inventory_view);
        }

        // DELETE: api/inventory_view/5
        [ResponseType(typeof(inventory_view))]
        public async Task<IHttpActionResult> Deleteinventory_view(string id)
        {
            inventory_view inventory_view = await _db.inventory_view.FindAsync(id);
            if (inventory_view == null)
            {
                return NotFound();
            }

            _db.inventory_view.Remove(inventory_view);
            await _db.SaveChangesAsync();

            return Ok(inventory_view);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool inventory_viewExists(string id)
        {
            return _db.inventory_view.Count(e => e.ProductName == id) > 0;
        }
    }
}
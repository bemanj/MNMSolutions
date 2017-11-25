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
using MNMSolutions.DAL.BLL.Inventory;

namespace MNMSolutions.Web.Api.Controllers.Inventory
{
    public class InventoryStocksController : ApiController
    {
        private InventoryFunction inventoryFunction = new InventoryFunction();
        private MNMSolutionsDevDBEntities db = new MNMSolutionsDevDBEntities();

        // GET: api/InventoryStocks
        public IQueryable<InventoryStock> GetInventoryStocks()
        {
            return db.InventoryStocks;
        }

        // GET: api/InventoryStocks/5
        [ResponseType(typeof(InventoryStock))]
        public IHttpActionResult GetInventoryStock(int id)
        {
            InventoryStock inventoryStock = db.InventoryStocks.Find(id);
            if (inventoryStock == null)
            {
                return NotFound();
            }

            return Ok(inventoryStock);
        }

        // PUT: api/InventoryStocks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventoryStock(int id, InventoryStock inventoryStock)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != inventoryStock.StockId)
            //{
            //    return BadRequest();
            //}

            //db.Entry(inventoryStock).State = EntityState.Modified;

            try
            {
                inventoryFunction.UpdateInventory(id, inventoryStock);
                //db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryStockExists(id))
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

        // POST: api/InventoryStocks
        [ResponseType(typeof(InventoryStock))]
        public IHttpActionResult PostInventoryStock(InventoryStock inventoryStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InventoryStocks.Add(inventoryStock);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inventoryStock.StockId }, inventoryStock);
        }

        // DELETE: api/InventoryStocks/5
        [ResponseType(typeof(InventoryStock))]
        public IHttpActionResult DeleteInventoryStock(int id)
        {
            InventoryStock inventoryStock = db.InventoryStocks.Find(id);
            if (inventoryStock == null)
            {
                return NotFound();
            }

            db.InventoryStocks.Remove(inventoryStock);
            db.SaveChanges();

            return Ok(inventoryStock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryStockExists(int id)
        {
            return db.InventoryStocks.Count(e => e.StockId == id) > 0;
        }
    }
}
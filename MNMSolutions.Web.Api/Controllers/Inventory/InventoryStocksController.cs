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
using MNMSolutions.DAL.Repository;

namespace MNMSolutions.Web.Api.Controllers.Inventory
{
    public class InventoryStocksController : ApiController
    {
        //private MNMSolutionsDevDBEntities db = new MNMSolutionsDevDBEntities();

        #region Global Declaration
        private readonly IRepository<InventoryStock> _inventoryStockRepository = null;

        public InventoryStocksController()
        {
            this._inventoryStockRepository= new Repository<InventoryStock>();
        }
        #endregion

        // GET: api/InventoryStocks
        public IEnumerable<InventoryStock> GetInventoryStocks()
        {
            return _inventoryStockRepository.GetAll();
        }

        // GET: api/InventoryStocks/5
        [ResponseType(typeof(InventoryStock))]
        public IHttpActionResult GetInventoryStock(int id)
        {
            InventoryStock inventoryStock = _inventoryStockRepository.GetById(id);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventoryStock.StockId)
            {
                return BadRequest();
            }

            _inventoryStockRepository.Update(inventoryStock);

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

            _inventoryStockRepository.Insert(inventoryStock);

            return CreatedAtRoute("DefaultApi", new { id = inventoryStock.StockId }, inventoryStock);
        }

        // DELETE: api/InventoryStocks/5
        [ResponseType(typeof(InventoryStock))]
        public IHttpActionResult DeleteInventoryStock(int id)
        {
            var inventoryStock = _inventoryStockRepository.GetById(id);
            if (inventoryStock == null)
            {
                return NotFound();
            }

            _inventoryStockRepository.Delete(inventoryStock);

            return Ok(inventoryStock);
        }

    }
}
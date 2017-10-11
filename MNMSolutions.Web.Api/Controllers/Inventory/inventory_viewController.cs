using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MNMSolutions.DAL.DB.Dev;
using MNMSolutions.DAL.Repository;

namespace MNMSolutions.Web.Api.Controllers.Inventory
{
    public class InventoryViewController : ApiController
    {
        #region Global Declaration
        private readonly IRepository<inventory_view> _inventoryViewRepository = null;

        public InventoryViewController()
        {
            this._inventoryViewRepository = new Repository<inventory_view>();
        }
        #endregion

        // GET: api/InventoryStocks
        public IEnumerable<inventory_view> GetInventoryStocks()
        {
            return _inventoryViewRepository.GetAll();
        }
    }
}

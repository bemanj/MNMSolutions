using MNMSolutions.DAL.DB.Dev;
using MNMSolutions.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNMSolutions.BLL
{
    public class Inventory
    {
        #region Global Declaration
        private readonly IRepository<InventoryStock> _inventoryStockRepository = null;

        public Inventory()
        {
            this._inventoryStockRepository = new Repository<InventoryStock>();
        }
        #endregion



    }
}

using System;
using System.Linq;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.DAL.BLL.Inventory
{
    public class InventoryFunction
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        //public IQueryable<ProductOne> ReturnTaxFreeProductList()
        //{
        //    var list = _db.ProductOnes.Where(p => p.isTaxFree == true);

        //    return list;
        //}

        public void UpdateInventory(int id, InventoryStock _i)
        {
            
            var r = _db.InventoryStocks.SingleOrDefault(d => d.StockId == id);
            if (r != null)
            {
                // Columns to update
                r.SupplierId = _i.SupplierId;
                r.ProductId = _i.ProductId;
                r.Brand = _i.Brand;
                r.Article = _i.Article;
                r.Price = _i.Price;
                r.Quantity = _i.Quantity;
                r.AcquisitionPrice = _i.AcquisitionPrice;
                r.UOM = _i.UOM;
                r.PONumber = _i.PONumber;
                r.PutAwayLocation = _i.PutAwayLocation;
                r.ModifiedDate = DateTime.Now;

                // save to Database
                _db.SaveChanges();
            }

        }
    }
}

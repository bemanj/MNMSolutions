using System.Linq;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.DAL.BLL.Product
{
    public class ProductList
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        public IQueryable<ProductOne> ReturnTaxFreeProductList()
        {
            var list = _db.ProductOnes.Where(p => p.isTaxFree == true);

            return list;
        }

        public void UpdateProduct(int id, ProductOne _p)
        {
            var r = _db.ProductOnes.SingleOrDefault(d => d.ProductId== id);
            if (r != null)
            {
                // Columns to update
                r.CategoryID = _p.CategoryID;
                r.ProductTitle = _p.ProductTitle;
                //r.UnitsInStock = _p.UnitsInStock;
                //r.UnitsOnOrder = _p.UnitsOnOrder;
                r.ReorderLevel = _p.ReorderLevel;
                r.Discontinued = _p.Discontinued;
                r.isTaxFree = _p.isTaxFree;

                // save to Database
                _db.SaveChanges();
            }

        }
    }
}

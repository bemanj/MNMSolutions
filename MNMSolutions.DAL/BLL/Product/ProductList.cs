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
    }
}

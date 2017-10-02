using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.BLL
{
    public class ProductList
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/ProductOnes
        public IQueryable<ProductOne> GetProductOnes()
        {
            return _db.ProductOnes;
        }
    }
}

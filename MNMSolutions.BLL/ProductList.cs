using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNMSolutions.DAL.DB.Dev;
using MNMSolutions.DAL.Repository;

namespace MNMSolutions.BLL
{
    public class ProductList
    {
        //private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        #region Global Declaration
        private readonly IRepository<ProductOne> _productListRepository = null;

        public ProductList()
        {
            this._productListRepository = new Repository<ProductOne>();
        }
        #endregion
        // GET: api/ProductOnes
        public IEnumerable<ProductOne> GetProductOnes()
        {
            return _productListRepository.GetAll();
        }
    }
}

using System.Linq;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.DAL.BLL.Product
{
    public sealed class SupplierFunction
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        //public IQueryable<ProductOne> ReturnTaxFreeProductList()
        //{
        //    var list = _db.ProductOnes.Where(p => p.isTaxFree == true);

        //    return list;
        //}

        public void UpdateSupplier(int id, Supplier _s)
        {
            var s = _db.Suppliers.SingleOrDefault(d => d.SupplierID == id);
            if (s != null)
            {
                // Columns to update
                //s.SupplierID = _s.SupplierID;
                s.CompanyName = _s.CompanyName;
                s.ContactName = _s.ContactName;
                s.ContactTitle = _s.ContactTitle;
                s.Address = _s.Address;
                s.City = _s.City;
                s.Region = _s.Region;
                s.PostalCode = _s.PostalCode;
                s.Country = _s.Country;
                s.Phone = _s.Phone;
                s.Fax = _s.Fax;
                s.HomePage = _s.HomePage;
                // save to Database
                _db.SaveChanges();
            }

        }
    }
}

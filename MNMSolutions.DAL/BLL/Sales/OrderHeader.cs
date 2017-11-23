using System.Linq;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.DAL.BLL.Sales
{
    public class OrderHeaderFunctions
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        public  void UpdateTotalDue(int id, SalesOrderHeader _soHeader)
        {
            var result = _db.SalesOrderHeaders.SingleOrDefault(d => d.SalesOrderID == id);
            if (result != null)
            {
                result.TotalDue = _soHeader.TotalDue;
                _db.SaveChanges();
            }

        }

        public void CompleteOrder(int id)
        {
            var result = _db.SalesOrderHeaders.SingleOrDefault(d => d.SalesOrderID == id);
            if (result != null)
            {
                result.Fulfilled = true;
                _db.SaveChanges();
            }

        }
    }
}

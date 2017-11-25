using System;
using System.Linq;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.DAL.BLL.Sales
{
    public class OrderHeaderFunctions
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        public void UpdateSalesOrder(int id, SalesOrderHeader _s)
        {
            var r = _db.SalesOrderHeaders.SingleOrDefault(d => d.SalesOrderID == id);
            if (r != null)
            {
                r.Customer = _s.Customer;
                r.OnlineOrderFlag = _s.OnlineOrderFlag;
                r.Comment = _s.Comment;
                r.ModifiedDate = DateTime.Now;
                r.Fulfilled = _s.Fulfilled;
                r.ComputeTax = _s.ComputeTax;

                // verify is Fulfilled = true
                if (_s.Fulfilled == true)
                {
                    r.OrderDate = DateTime.Now;
                }

                _db.SaveChanges();
            }

        }

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

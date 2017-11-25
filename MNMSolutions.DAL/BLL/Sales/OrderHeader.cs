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

        public SalesOrderHeader CreateSalesOrder(SalesOrderHeader _s)
        {
            SalesOrderHeader so = new SalesOrderHeader
            {
                Comment = _s.Comment,
                ComputeTax = true,
                CreatedDate = DateTime.Now,
                Customer = null,
                Freight = 0,
                Fulfilled = false,
                ModifiedDate = null,
                OnlineOrderFlag = null,
                OrderDate = null,
                //SalesOrderID = 0,
                SalesOrderNumber = null,
                SubTotal = 0,
                TaxAmt = 0,
                TaxFreeAmt = 0,
                TaxableAmt = 0,
                TotalDue = 0,
                TotalDueAmt = 0,
                isSettled = false,
            };

            _db.SalesOrderHeaders.Add(so);
            _db.SaveChanges();

            return so;
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

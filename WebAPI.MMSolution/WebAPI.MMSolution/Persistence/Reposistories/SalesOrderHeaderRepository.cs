using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.MMSolution.Core.Domain;
using WebAPI.MMSolution.Core.InterfaceRepositories;
using WebAPI.MMSolution.Models;


namespace WebAPI.MMSolution.Persistence.Reposistories
{
    public class SalesOrderHeaderRepository : Repository<SalesOrderHeaders>, ISalesOrderHeaderRepository
    {
        public SalesOrderHeaderRepository(DbContext context) : base(context)
        {
        }

        public void Delete(int SalesOrderHeaderID)
        {
            using (var _db = new MNMSolutionsDevDBEntities())
            {
                var _SalesorderHeader = _db.SalesOrderHeaders.Where(o => o.SalesOrderID == SalesOrderHeaderID).FirstOrDefault();
                _db.SalesOrderHeaders.Remove(_SalesorderHeader);
                _db.SaveChanges();
            }
        }

        public IList<SalesOrderHeaders> GetBSalesOrderHeaderID(int SalesOrderHeaderID)
        {
            IList<SalesOrderHeaders> _SalesOrderHeader = new List<SalesOrderHeaders>();
            using (var _db = new MNMSolutionsDevDBEntities())
            {
                var results = _db.GetSOHtBySID(SalesOrderHeaderID).ToList();

                if (results != null)
                {
                    foreach (var item in results.ToList())

                    {
                        _SalesOrderHeader.Add(new SalesOrderHeaders
                        {

                            SalesOrderID = item.SalesOrderID,
                            Customer = item.Customer,
                            OrderDate = item.OrderDate,
                            OnlineOrderFlag = item.OnlineOrderFlag,
                            SalesOrderNumber = item.SalesOrderNumber,
                            SubTotal = item.SubTotal,
                            TaxAmt = item.TaxAmt,
                            TotalDue = item.TotalDue,
                            Comment = item.Comment,
                            ModifiedDate = item.ModifiedDate,
                            Fulfilled = item.Fulfilled
                        });
                    }
                }
            }
            return _SalesOrderHeader.ToList();
        }

        public void Insert(SalesOrderHeaders d)
        {
            using (var _db = new MNMSolutionsDevDBEntities())
            {
                _db.SalesOrderHeaders.Add(new SalesOrderHeader
                {
                    Customer = d.Customer,
                    OnlineOrderFlag = d.OnlineOrderFlag,
                    SubTotal = d.SubTotal,
                    TaxAmt = d.TaxAmt,
                    Freight= d.Freight,
                    TotalDue =d.TotalDue,
                    Comment= d.Comment,
                    Fulfilled=d.Fulfilled
                });
                _db.SaveChanges();
            }
        }

        public void Update(SalesOrderHeaders d)
        {
            using (var _db = new MNMSolutionsDevDBEntities())
            {
                var _SalesOrderHeader = _db.SalesOrderHeaders.Where(o => o.SalesOrderID == d.SalesOrderID).FirstOrDefault();
                _SalesOrderHeader.SalesOrderID=d.SalesOrderID;
                _SalesOrderHeader.Customer = d.Customer;
                _SalesOrderHeader.OnlineOrderFlag = d.OnlineOrderFlag;
                _SalesOrderHeader.SubTotal = d.SubTotal;
                _SalesOrderHeader.TaxAmt = d.TaxAmt;
                _SalesOrderHeader.Freight = d.Freight;
                _SalesOrderHeader.TotalDue = d.TotalDue;
                _SalesOrderHeader.Comment = d.Comment;
                _SalesOrderHeader.Fulfilled = d.Fulfilled;
                _db.SaveChanges();
            }
        }
    }
}
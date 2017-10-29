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
    public class SalesOrderDetailsRepository : Repository<SalesOrderDetails>, ISalesOrderDetailsRepository
    {
        public SalesOrderDetailsRepository(DbContext context) : base(context)
        {
        }

        public void Delete(int SODetailsID)
        {
            using (var _db = new MNMSolutionsDevDBEntities())
            {
                var _SalesorderDetail = _db.SalesOrderDetails.Where(o => o.SODetailsID == SODetailsID).FirstOrDefault();
                _db.SalesOrderDetails.Remove(_SalesorderDetail);
                _db.SaveChanges();
            }
        }

        public IList<SalesOrderDetails> GetSalesOrderDetailByID(int SODetailsID)
        {
            IList<SalesOrderDetails> _SalesOrderDetails = new List<SalesOrderDetails>();
            using (var _db = new MNMSolutionsDevDBEntities())
            {
                var results = _db.GetSODetailsByID(SODetailsID).ToList();

                if (results != null)
                {
                    foreach (var item in results.ToList())

                    {
                        _SalesOrderDetails.Add(new SalesOrderDetails
                        {
                            SODetailsID = item.SODetailsID,
                            SalesOrderID = item.SalesOrderID,
                            StockID = item.StockID,
                            ProductID = item.ProductID,
                            UnitPrice = item.UnitPrice,
                            Article = item.Article,
                            UOM = item.UOM,
                            Quantity = item.Quantity,
                            Discount = item.Discount,
                            TotalAmount = item.TotalAmount
                        });
                    }
                }
            }
            return _SalesOrderDetails.ToList();
        }

        public void Insert(SalesOrderDetails d)
        {
            using (var _db = new MNMSolutionsDevDBEntities())
            {
                _db.SalesOrderDetails.Add(new SalesOrderDetail
                {
                    SalesOrderID = d.SalesOrderID,
                    StockID = d.StockID,
                    ProductID = d.ProductID,
                    UnitPrice = d.UnitPrice,
                    Article = d.Article,
                    UOM = d.UOM,
                    Quantity = d.Quantity,
                    Discount = d.Discount,
                    TotalAmount = d.TotalAmount
                });
                _db.SaveChanges();
            }
        }

        public void Update(SalesOrderDetails d)
        {
            using (var _db = new MNMSolutionsDevDBEntities())
            {
                var _SalesOrderDetails = _db.SalesOrderDetails.Where(o => o.SODetailsID == d.SODetailsID).FirstOrDefault();
                _SalesOrderDetails.SODetailsID = d.SODetailsID;
                _SalesOrderDetails.SalesOrderID = d.SalesOrderID;
                _SalesOrderDetails.StockID = d.StockID;
                _SalesOrderDetails.ProductID = d.ProductID;
                _SalesOrderDetails.UnitPrice = d.UnitPrice;
                _SalesOrderDetails.Article = d.Article;
                _SalesOrderDetails.UOM = d.UOM;
                _SalesOrderDetails.Quantity = d.Quantity;
                _SalesOrderDetails.Discount = d.Discount;
                _SalesOrderDetails.TotalAmount = d.TotalAmount;
                _db.SaveChanges();
            }
        }
    }
}
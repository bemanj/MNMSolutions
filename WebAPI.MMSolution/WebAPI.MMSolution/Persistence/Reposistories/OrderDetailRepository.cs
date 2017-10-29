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
    public class OrderDetailRepository : Repository<OrderDetails>, IOrderDetailRepository
    {

        public OrderDetailRepository(DbContext context) : base(context)
        {
        }

        public void Insert(OrderDetails d)
        {
            using (var _db = new MNMSolutionsDevDBEntities())
            {
                _db.OrderDetails.Add(new OrderDetail
                {

                    OrderID = d.OrderID
                    ,
                    ProductID = d.ProductID
                    ,
                    UnitPrice = d.UnitPrice
                    ,
                    Quantity = d.Quantity
                    ,
                    Discount = d.Discount
                    ,
                    TotalAmount = d.TotalAmount
                });
                _db.SaveChanges();
            }

        }

        public void Delete(int OrderID, int ProductID)
        {
            using (var _db = new MNMSolutionsDevDBEntities())
            {
                var _orderDetail = _db.OrderDetails.Where(o => o.OrderID == OrderID && o.ProductID == ProductID).FirstOrDefault();
                _db.OrderDetails.Remove(_orderDetail);
                _db.SaveChanges();
            }
        }

        public void Update(OrderDetails d)
        {
            using (var _db = new MNMSolutionsDevDBEntities())
            {
                var _orderDetail = _db.OrderDetails.Where(o => o.OrderID == d.OrderID && o.ProductID == d.ProductID).FirstOrDefault();
                _orderDetail.UnitPrice = d.UnitPrice;
                _orderDetail.Quantity = d.Quantity;
                _orderDetail.Discount = d.Discount;
                _orderDetail.TotalAmount = d.TotalAmount;
                _db.SaveChanges();
            }
        }

        public IList<OrderDetails> GetByOrderIDProductID(int OrderID, int ProductID)
        {
            IList<OrderDetails> _orderDetail = new List<OrderDetails>();
            using (var _db = new MNMSolutionsDevDBEntities())
            {
                var results = _db.GetOrderDetailBy_OrderID_ProductID(OrderID, ProductID).ToList();

                if (results != null)
                {
                    foreach (var item in results.ToList())

                    {
                        _orderDetail.Add(new OrderDetails
                        {
                            OrderID = item.OrderID,
                            ProductID = item.ProductID
                        });
                    }
                }
            }
            return _orderDetail.ToList();

        }


        //public MNMSolutionsDevDBEntities Context
        //{
        //    get { return Context as MNMSolutionsDevDBEntities; }

        //}

    }
}
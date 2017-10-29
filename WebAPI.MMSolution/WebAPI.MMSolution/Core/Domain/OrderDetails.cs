using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.MMSolution.Core.Domain
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 Quantity { get; set; }
        public Single Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
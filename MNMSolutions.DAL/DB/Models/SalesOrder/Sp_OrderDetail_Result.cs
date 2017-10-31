using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNMSolutions.DAL.DB.Models.SalesOrder
{
    using System;

    public partial class SpOrderDetailResult
    {
        public int SoDetailsId { get; set; }
        public int SalesOrderId { get; set; }
        public int StockId { get; set; }
        public string SalesOrderNumber { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Uom { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string ProductName { get; set; }
    }
}

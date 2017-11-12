using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNMSolutions.DAL.Models.Sales.Order
{
    public class OrderHeader
    {
        public int SalesOrderId { get; set; }
        public int? Customer { get; set; }
        public string OnlineOrderFlag { get; set; }
        //public decimal SubTotal { get; set; }
        //public decimal TaxAmt { get; set; }
        //public decimal Freight { get; set; }
        //public decimal TotalDue { get; set; }
        public string Comment { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Fulfilled { get; set; }
    }
}

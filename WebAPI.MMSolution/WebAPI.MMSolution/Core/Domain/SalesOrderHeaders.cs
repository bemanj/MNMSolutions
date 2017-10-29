using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.MMSolution.Core.Domain
{
    public class SalesOrderHeaders
    {
        public int SalesOrderID { get; set; }
        public string Customer { get; set; }
        public Nullable<DateTime> OrderDate { get; set; }
        public string OnlineOrderFlag { get; set; }
        public string SalesOrderNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<bool> Fulfilled { get; set; }
    }
}
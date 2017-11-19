using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNMSolutions.DAL.Models.Sales.Order
{
    public class OrderDetail
    {
        public int SalesDetailsId { get; set; }
        public float Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

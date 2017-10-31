using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNMSolutions.DAL.Models
{
    using System;

    public partial class InventoryStockUpdate
    {
        public int StockId { get; set; }
        public int PONumber { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public string UOM { get; set; }
        public string Article { get; set; }
        public decimal Price { get; set; }
        public decimal AcquisitionPrice { get; set; }
        public Nullable<System.DateTime> DateDisposed { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int PutAwayLocation { get; set; }
    }
}

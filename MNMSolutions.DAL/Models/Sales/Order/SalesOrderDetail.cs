namespace MNMSolutions.DAL.Models.Sales.Order
{
    public partial class SalesOrderDetailv2
    {
        public int SODetailsID { get; set; }
        public int SalesOrderID { get; set; }
        public int StockID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public string Article { get; set; }
        public string UOM { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool addTax { get; set; }
    }
}

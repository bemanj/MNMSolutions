namespace MNMSolutions.DAL.Models.Sales.Order
{
    public class OrderDetail
    {
        public int SalesDetailsId { get; set; }
        public int SalesOrderID { get; set; }
        public float Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

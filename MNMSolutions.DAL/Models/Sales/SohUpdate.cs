namespace MNMSolutions.DAL.Models.Sales
{
    public class SohUpdate
    {
        public short SalesOrderId { get; set; }
        public short Customer { get; set; }
        public string OnlineOrderFlag { get; set; }
        public short SubTotal { get; set; }
        public short TaxAmt  { get; set; }
        public short Freight { get; set; }
        public string Comment { get; set; }
        public bool Fulfilled { get; set; }
    }
}

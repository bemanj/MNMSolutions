namespace MNMSolutions.DAL.Models.Customer
{
    public class NewProduct
    {
        public short CategoryId { get; set; }
        public string ProductTitle { get; set; }
        public short ReorderLevel { get; set; }
    }
}

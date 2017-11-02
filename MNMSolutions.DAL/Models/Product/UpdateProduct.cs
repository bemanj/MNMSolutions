namespace MNMSolutions.DAL.Models.Customer
{
    public class UpdateProduct
    {
        public short ProductId { get; set; }
        public short CategoryId { get; set; }
        public string ProductTitle { get; set; }
        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        
    }
}

namespace Centric.eCommerce.Search.API.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

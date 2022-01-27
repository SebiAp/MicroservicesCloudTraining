namespace Centric.eCommerce.Search.API.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}

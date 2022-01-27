namespace Centric.eCommerce.Order.API.DB
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}

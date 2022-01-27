namespace Centric.eCommerce.Order.API.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get { return Items.Sum(oi => oi.UnitPrice * oi.Quantity); } }
        public List<OrderItemModel> Items { get; set; }
    }
}

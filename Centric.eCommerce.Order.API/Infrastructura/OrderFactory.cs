using Centric.eCommerce.Order.API.DB;

namespace Centric.eCommerce.Order.API.Infrastructura
{
    public static class OrderFactory
    {
        public static OrdersDbContext SeedOrders(this OrdersDbContext context)
        {
            if (!context.Orders.Any())
            {
                context.Orders.Add(new DB.Order()
                {
                    Id = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"),
                    CustomerId = new Guid("52eb3859-5391-49cc-a7b5-a9ff95f47f88"),
                    OrderDate = DateTime.Now,
                    Items = new List<OrderItem>()
                    {
                        new OrderItem() { OrderId = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("6C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("5C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("4C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = new Guid("4cb0c381-3f9d-460c-9796-2635c500eb46"), ProductId = new Guid("5C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = new Guid("4cb0c381-3f9d-460c-9796-2635c500eb46"), ProductId = new Guid("4C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                context.Orders.Add(new DB.Order()
                {
                    Id = new Guid("4cb0c381-3f9d-460c-9796-2635c500eb46"),
                    CustomerId = new Guid("3aa28481-455f-46ce-838d-06f69547ea7d"),
                    OrderDate = DateTime.Now.AddDays(-1),
                    Items = new List<OrderItem>()
                    {
                        new OrderItem() { OrderId = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("3C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("5C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("6C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = new Guid("4cb0c381-3f9d-460c-9796-2635c500eb46"), ProductId = new Guid("5C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = new Guid("4cb0c381-3f9d-460c-9796-2635c500eb46"), ProductId = new Guid("6C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                context.Orders.Add(new DB.Order()
                {
                    Id = new Guid("87c7c2b7-1279-42c8-9667-beb9e1c897e6"),
                    CustomerId = new Guid("3aa28481-455f-46ce-838d-06f69547ea7d"),
                    OrderDate = DateTime.Now,
                    Items = new List<OrderItem>()
                    {
                        new OrderItem() {
                            OrderId =new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("5C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = new Guid("4cb0c381-3f9d-460c-9796-2635c500eb46"), ProductId = new Guid("4C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = new Guid("87c7c2b7-1279-42c8-9667-beb9e1c897e6"), ProductId = new Guid("3C60378B-71D5-4920-B763-6AFCADA6267E"), Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                context.SaveChanges();
            }
            return context;
        }
    }
}

using Centric.eCommerce.Order.API.DB;

namespace Centric.eCommerce.Order.API.Infrastructure
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
                    CustomerId = new Guid("16bb5b1d-a0fc-4750-8f5e-3e976a4ad491"),
                    OrderDate = DateTime.Now,
                    Items = new List<OrderItem>()
                    {
                        new() { OrderId = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("81D60B76-87CF-4F95-AFE0-9F39A46D0F00"), Quantity = 10, UnitPrice = 10 },
                        new() { OrderId = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("D23D3182-949B-4F31-A49E-9F602E5E9546"), Quantity = 10, UnitPrice = 10 },
                        new() { OrderId = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("150B9130-B5F4-4B5B-887A-4F0243A85D75"), Quantity = 10, UnitPrice = 10 },
                        new() { OrderId = new Guid("4cb0c381-3f9d-460c-9796-2635c500eb46"), ProductId = new Guid("F454975A-AC17-4EC2-A8E8-0A11DE0B4CBA"), Quantity = 10, UnitPrice = 10 },
                        new() { OrderId = new Guid("4cb0c381-3f9d-460c-9796-2635c500eb46"), ProductId = new Guid("150B9130-B5F4-4B5B-887A-4F0243A85D75"), Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                context.Orders.Add(new DB.Order()
                {
                    Id = new Guid("4cb0c381-3f9d-460c-9796-2635c500eb46"),
                    CustomerId = new Guid("0de08659-cef1-4cfd-a8f9-64e09d3d1574"),
                    OrderDate = DateTime.Now.AddDays(-1),
                    Items = new List<OrderItem>()
                    {
                        new() { OrderId = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("81D60B76-87CF-4F95-AFE0-9F39A46D0F00"), Quantity = 10, UnitPrice = 10 },
                        new() { OrderId = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("D23D3182-949B-4F31-A49E-9F602E5E9546"), Quantity = 10, UnitPrice = 10 },
                        new() { OrderId = new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("150B9130-B5F4-4B5B-887A-4F0243A85D75"), Quantity = 10, UnitPrice = 10 },
                        new() { OrderId = new Guid("4cb0c381-3f9d-460c-9796-2635c500eb46"), ProductId = new Guid("F454975A-AC17-4EC2-A8E8-0A11DE0B4CBA"), Quantity = 10, UnitPrice = 10 },
                        new() { OrderId = new Guid("4cb0c381-3f9d-460c-9796-2635c500eb46"), ProductId = new Guid("150B9130-B5F4-4B5B-887A-4F0243A85D75"), Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                context.Orders.Add(new DB.Order()
                {
                    Id = new Guid("87c7c2b7-1279-42c8-9667-beb9e1c897e6"),
                    CustomerId = new Guid("034fa66b-3c11-4efc-984d-948a8b433e37"),
                    OrderDate = DateTime.Now,
                    Items = new List<OrderItem>()
                    {
                        new() {
                            OrderId =new Guid("ed83a911-a078-4b5c-bda0-8a4e80f32b39"), ProductId = new Guid("81D60B76-87CF-4F95-AFE0-9F39A46D0F00"), Quantity = 10, UnitPrice = 10 },
                        new() { OrderId = new Guid("4cb0c381-3f9d-460c-9796-2635c500eb46"), ProductId = new Guid("150B9130-B5F4-4B5B-887A-4F0243A85D75"), Quantity = 10, UnitPrice = 10 },
                        new() { OrderId = new Guid("87c7c2b7-1279-42c8-9667-beb9e1c897e6"), ProductId = new Guid("F454975A-AC17-4EC2-A8E8-0A11DE0B4CBA"), Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                context.SaveChanges();
            }
            return context;
        }
    }
}

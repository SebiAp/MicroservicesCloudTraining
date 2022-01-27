using Centric.eCommerce.Customer.API.DB;

namespace Centric.eCommerce.Customer.API.Infrastructure
{
    public static class CustomersFactory
    {
        public static CustomersDbContext SeedCustomers(this CustomersDbContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.Add(new DB.Customer()
                {
                    Id = new Guid("16bb5b1d-a0fc-4750-8f5e-3e976a4ad491"),
                    Name = "Customer 1",
                    Address = "Address Customer 1"
                });
                context.Customers.Add(new DB.Customer()
                {
                    Id = new Guid("0de08659-cef1-4cfd-a8f9-64e09d3d1574"),
                    Name = "Customer 2",
                    Address = "Address Customer 2"
                });
                context.Customers.Add(new DB.Customer()
                {
                    Id = new Guid("034fa66b-3c11-4efc-984d-948a8b433e37"),
                    Name = "Customer 3",
                    Address = "Address Customer 3"
                });
                context.Customers.Add(new DB.Customer()
                {
                    Id = new Guid("b4cc9241-2dea-41e3-8b36-38c50861d1e0"),
                    Name = "Customer 4",
                    Address = "Address Customer 4"
                });
                context.SaveChanges();
            }

            return context;
        }
    }
}

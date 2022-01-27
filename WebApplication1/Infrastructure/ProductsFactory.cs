using Centric.eCommerce.Product.API.DB;

namespace Centric.eCommerce.Product.API.Infrastructure
{
    public static class ProductsFactory
    {
        public static ProductsDbContext SeedProducts(this ProductsDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.Add(new DB.Product()
                {
                    Id = new Guid("81D60B76-87CF-4F95-AFE0-9F39A46D0F00"),
                    Name = "Keyboard",
                    Price = 20,
                    Inventory = 100
                });
                context.Products.Add(new DB.Product()
                {
                    Id = new Guid("150B9130-B5F4-4B5B-887A-4F0243A85D75"),
                    Name = "Mouse",
                    Price = 5,
                    Inventory = 200
                });
                context.Products.Add(new DB.Product()
                {
                    Id = new Guid("F454975A-AC17-4EC2-A8E8-0A11DE0B4CBA"),
                    Name = "Monitor",
                    Price = 150,
                    Inventory = 20
                });
                context.Products.Add(new DB.Product()
                {
                    Id = new Guid("D23D3182-949B-4F31-A49E-9F602E5E9546"),
                    Name = "CPU",
                    Price = 200,
                    Inventory = 20
                });
                context.SaveChanges();
            }

            return context;
        }
    }
}

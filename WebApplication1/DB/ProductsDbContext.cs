using Microsoft.EntityFrameworkCore;

namespace Centric.eCommerce.Product.API.DB
{
    public class ProductsDbContext: DbContext
    {
        public ProductsDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}

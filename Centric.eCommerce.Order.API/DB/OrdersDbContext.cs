using Microsoft.EntityFrameworkCore;

namespace Centric.eCommerce.Order.API.DB
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}

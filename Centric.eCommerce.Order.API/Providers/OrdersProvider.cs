using AutoMapper;
using Centric.eCommerce.Order.API.DB;
using Centric.eCommerce.Order.API.Infrastructure;
using Centric.eCommerce.Order.API.Interfaces;
using Centric.eCommerce.Order.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Centric.eCommerce.Order.API.Providers
{
    public class OrdersProvider : IOrdersProvider
    {
        private readonly OrdersDbContext context;
        private readonly ILogger<OrdersProvider> logger;
        private readonly IMapper mapper;

        public OrdersProvider(OrdersDbContext context, ILogger<OrdersProvider> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
            context.SeedOrders();
        }

        public async Task<(bool IsSuccess, IEnumerable<OrderModel> Orders, string ErrorMessage)> GetOrdersAsync(Guid customerId)
        {
            try
            {
                var orders = await context.Orders.Where(o => o.CustomerId == customerId).Include(oi => oi.Items).ToListAsync();
                if (orders != null && orders.Any())
                {
                    var result = mapper.Map<IEnumerable<DB.Order>, IEnumerable<OrderModel>>(orders);
                    return (true, result, null);
                }

                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}

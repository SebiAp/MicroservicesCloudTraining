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
        private readonly OrdersDbContext _context;
        private readonly ILogger<OrdersProvider> _logger;
        private readonly IMapper _mapper;

        public OrdersProvider(OrdersDbContext context, ILogger<OrdersProvider> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            context.SeedOrders();
        }

        public async Task<(bool IsSuccess, IEnumerable<OrderModel> Orders, string ErrorMessage)> GetOrdersAsync(Guid customerId)
        {
            try
            {
                var orders = await _context.Orders.Where(o => o.CustomerId == customerId).Include(oi => oi.Items).ToListAsync();
                if (!orders.Any()) 
                    
                    return (false, null, "Not Found");

                var result = _mapper.Map<IEnumerable<DB.Order>, IEnumerable<OrderModel>>(orders);
                return (true, result, null);

            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}

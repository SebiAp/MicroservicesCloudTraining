using AutoMapper;
using Centric.eCommerce.Customer.API.DB;
using Centric.eCommerce.Customer.API.Infrastructure;
using Centric.eCommerce.Customer.API.Interfaces;
using Centric.eCommerce.Customer.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Centric.eCommerce.Customer.API.Providers
{
    public class CustomersProvider: ICustomersProvider
    {
        private readonly CustomersDbContext _context;
        private readonly ILogger<CustomersProvider> _logger;
        private readonly IMapper _mapper;

        public CustomersProvider(CustomersDbContext context, ILogger<CustomersProvider> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _context.SeedCustomers();
        }

        public async Task<(bool IsSuccess, IEnumerable<CustomerModel> Customers, string ErrorMessage)> GetCustomersAsync()
        {
            try
            {
                var customers = await _context.Customers.ToListAsync();
                if (customers != null && customers.Any())
                {
                    var result = _mapper.Map<IEnumerable<CustomerModel>>(customers);
                    return (true, result, null);
                }

                return (false, null, "Not found!");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, CustomerModel Customer, string ErrorMessage)> GetCustomerAsync(Guid id)
        {
            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(p => p.Id == id);
                if (customer != null)
                {
                    var result = _mapper.Map<CustomerModel>(customer);
                    return (true, result, null);
                }

                return (false, null, "Not found!");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}

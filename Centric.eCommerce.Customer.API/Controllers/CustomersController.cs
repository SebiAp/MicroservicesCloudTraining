using Centric.eCommerce.Customer.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Centric.eCommerce.Customer.API.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider _provider;

        public CustomersController(ICustomersProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var customers = await _provider.GetCustomersAsync();
            if (customers.IsSuccess)
            {
                return Ok(customers.Customers);
            }

            return NotFound(customers.ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(Guid id)
        {
            var customer = await _provider.GetCustomerAsync(id);
            if (customer.IsSuccess)
            {
                return Ok(customer.Customer);
            }

            return NotFound(customer.ErrorMessage);
        }
    }
}

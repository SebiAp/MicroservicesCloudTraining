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
        public async Task<IActionResult> GetCustomersAsync()
        {
            var (isSuccess, customers, errorMessage) = await _provider.GetCustomersAsync();
            if (isSuccess)
            {
                return Ok(customers);
            }

            return NotFound(errorMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomersAsync(Guid id)
        {
            var (isSuccess, customer, errorMessage) = await _provider.GetCustomerAsync(id);
            if (isSuccess)
            {
                return Ok(customer);
            }

            return NotFound(errorMessage);
        }
    }
}

using Centric.eCommerce.Order.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Centric.eCommerce.Order.API.Controllers
{
    [Route("api/v1/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider provider;

        public OrdersController(IOrdersProvider provider)
        {
            this.provider = provider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrdersAsync(Guid customerId)
        {
            var result = await provider.GetOrdersAsync(customerId);
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound(result.ErrorMessage);
        }
    }
}

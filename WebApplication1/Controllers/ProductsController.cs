using Centric.eCommerce.Product.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Centric.eCommerce.Product.API.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider _provider;

        public ProductsController(IProductsProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _provider.GetProductsAsync();
            if (products.IsSuccess)
            {
                return Ok(products.Products);
            }

            return NotFound(products.ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(Guid id)
        {
            var product = await _provider.GetProductAsync(id);
            if (product.IsSuccess)
            {
                return Ok(product.Product);
            }

            return NotFound(product.ErrorMessage);
        }
    }
}

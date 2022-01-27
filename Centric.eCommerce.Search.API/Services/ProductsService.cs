using System.Text.Json;
using Centric.eCommerce.Search.API.Interfaces;
using Centric.eCommerce.Search.API.Models;

namespace Centric.eCommerce.Search.API.Services;

public class ProductsService : IProductsService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<ProductsService> _logger;

    public ProductsService(IHttpClientFactory httpClientFactory, ILogger<ProductsService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<(bool IsSuccess, IEnumerable<Product>? Products, string? ErrorMessage)> GetProductsAsync()
    {
        try
        {
            var client = _httpClientFactory.CreateClient(nameof(ProductsService));
            var response = await client.GetAsync("api/v1/products");

            if (!response.IsSuccessStatusCode)
                return (false, null, response.ReasonPhrase);

            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<IEnumerable<Product>>(content, options);

            return (true, result, null);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return (false, null, ex.Message);
        }
    }
}
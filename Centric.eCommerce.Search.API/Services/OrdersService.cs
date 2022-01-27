using System.Text.Json;
using Centric.eCommerce.Search.API.Interfaces;
using Centric.eCommerce.Search.API.Models;

namespace Centric.eCommerce.Search.API.Services;

public class OrdersService : IOrdersService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<OrdersService> _logger;

    public OrdersService(IHttpClientFactory httpClientFactory, ILogger<OrdersService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<(bool IsSuccess, IEnumerable<Order>? Orders, string? ErrorMessage)> GetOrdersAsync(
        Guid customerId)
    {
        try
        {
            var client = _httpClientFactory.CreateClient(nameof(OrdersService));
            var response = await client.GetAsync($"api/v1/orders/{customerId}");

            if (!response.IsSuccessStatusCode)
                return (false, null, response.ReasonPhrase);

            var content = await response.Content.ReadAsByteArrayAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<IEnumerable<Order>>(content, options);

            return (true, result, null);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return (false, null, ex.Message);
        }
    }
}
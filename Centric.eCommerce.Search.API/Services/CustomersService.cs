using System.Text.Json;
using Centric.eCommerce.Search.API.Interfaces;

namespace Centric.eCommerce.Search.API.Services;

public class CustomersService: ICustomersService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<CustomersService> _logger;

    public CustomersService(IHttpClientFactory httpClientFactory, ILogger<CustomersService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<(bool IsSuccess, dynamic? Customer, string? ErrorMessage)> GetCustomerAsync(Guid id)
    {
        try
        {
            var client = _httpClientFactory.CreateClient(nameof(CustomersService));
            var response = await client.GetAsync($"api/v1/customers/{id}");

            if (!response.IsSuccessStatusCode)
                return (false, null, response.ReasonPhrase);

            var content = await response.Content.ReadAsByteArrayAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<dynamic>(content, options);

            return (true, result, null);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return (false, null, ex.Message);
        }
    }
}
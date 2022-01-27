using Centric.eCommerce.Search.API.Interfaces;

namespace Centric.eCommerce.Search.API.Services;

public class SearchService : ISearchService
{
    private readonly ICustomersService _customersService;
    private readonly IOrdersService _ordersService;
    private readonly IProductsService _productsService;

    public SearchService(IProductsService productsService,
        IOrdersService ordersService,
        ICustomersService customersService)
    {
        _productsService = productsService;
        _ordersService = ordersService;
        _customersService = customersService;
    }

    public async Task<(bool IsSuccess, dynamic? SearchResult)> SearchAsync(Guid customerId)
    {
        var customerResult = await _customersService.GetCustomerAsync(customerId);
        var ordersResult = await _ordersService.GetOrdersAsync(customerId);
        var productsResult = await _productsService.GetProductsAsync();

        if (!ordersResult.IsSuccess) return (false, null);

        if (ordersResult.Orders == null) 
            return (false, null);

        foreach (var order in ordersResult.Orders)

        foreach (var item in order.Items.Where(_ => productsResult.Products != null))
            if (productsResult.Products != null)
                item.ProductName = productsResult.IsSuccess
                    ? productsResult.Products.FirstOrDefault(p => p.Id == item.ProductId)?.Name
                    : "Product name is not available";

        var result = new
        {
            Customer = customerResult.IsSuccess ? customerResult.Customer : "Customer information is not available",
            ordersResult.Orders
        };

        return (true, result);

    }
}
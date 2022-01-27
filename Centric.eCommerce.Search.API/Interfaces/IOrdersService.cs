using Centric.eCommerce.Search.API.Models;

namespace Centric.eCommerce.Search.API.Interfaces
{
    public interface IOrdersService
    {
        Task<(bool IsSuccess, IEnumerable<Order>? Orders, string? ErrorMessage)> GetOrdersAsync(
            Guid customerId);
    }
}

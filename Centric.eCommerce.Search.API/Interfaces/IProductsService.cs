using Centric.eCommerce.Search.API.Models;

namespace Centric.eCommerce.Search.API.Interfaces
{
    public interface IProductsService
    {
        Task<(bool IsSuccess, IEnumerable<Product>? Products, string? ErrorMessage)> GetProductsAsync();
    }
}

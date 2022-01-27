using Centric.eCommerce.Product.API.Models;

namespace Centric.eCommerce.Product.API.Interfaces
{
    public interface IProductsProvider
    {
        Task<(bool IsSuccess, IEnumerable<ProductModel> Products, string ErrorMessage)> GetProductsAsync();
        Task<(bool IsSuccess, ProductModel Product, string ErrorMessage)> GetProductAsync(Guid id);
    }
}

using Centric.eCommerce.Customer.API.Models;

namespace Centric.eCommerce.Customer.API.Interfaces
{
    public interface ICustomersProvider
    {
        Task<(bool IsSuccess, IEnumerable<CustomerModel> Customers, string ErrorMessage)> GetCustomersAsync();
        Task<(bool IsSuccess, CustomerModel Customer, string ErrorMessage)> GetCustomerAsync(Guid id);
    }
}

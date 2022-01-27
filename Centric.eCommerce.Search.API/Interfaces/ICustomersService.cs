namespace Centric.eCommerce.Search.API.Interfaces;

public interface ICustomersService
{
    Task<(bool IsSuccess, dynamic? Customer, string? ErrorMessage)> GetCustomerAsync(Guid id);
}
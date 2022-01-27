namespace Centric.eCommerce.Order.API.Interfaces
{
    public interface IOrdersProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.OrderModel> Orders, string ErrorMessage)> GetOrdersAsync(Guid customerId);
    }
}

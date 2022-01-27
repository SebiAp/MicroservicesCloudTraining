namespace Centric.eCommerce.Search.API.Interfaces
{
    public interface ISearchService
    {
        Task<(bool IsSuccess, dynamic? SearchResult)> SearchAsync(Guid customerId);
    }
}

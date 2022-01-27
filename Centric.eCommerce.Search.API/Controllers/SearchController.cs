using Centric.eCommerce.Search.API.Interfaces;
using Centric.eCommerce.Search.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Centric.eCommerce.Search.API.Controllers;

    [Route("api/v1/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
        {
        _searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync([FromBody] SearchTerm term)
        {
        var (isSuccess, searchResult) = await _searchService.SearchAsync(term.CustomerId);

        return isSuccess ? (IActionResult)Ok(searchResult) : NotFound();
    }
}
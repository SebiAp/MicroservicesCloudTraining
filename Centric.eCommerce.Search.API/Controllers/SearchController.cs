using Centric.eCommerce.Search.API.Interfaces;
using Centric.eCommerce.Search.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Centric.eCommerce.Search.API.Controllers
{
    [Route("api/v1/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _service;

        public SearchController(ISearchService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync([FromBody] SearchTerm term)
        {
            var result = await _service.SearchAsync(term.CustomerId);
            if (result.IsSuccess)
            {
                return Ok(result.SearchResult);
            }

            return NotFound();
        }
    }
}

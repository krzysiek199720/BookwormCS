using Bookworm.Controllers.Services.Interfaces;
using Bookworm.DTO;
using Bookworm.DTO.Results;
using Bookworm.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm.Controllers;

public class SearchController : ApiBaseController
{
    public ISearchService SearchService { get; }

    public SearchController(ISearchService searchService)
    {
        SearchService = searchService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<BookMinimalDto>>> Search([FromQuery] SearchRequest searchParams)
    {
        var result = SearchService.SearchBook(searchParams);
        return result;
    }
    
    [HttpGet("author")]
    public async Task<ActionResult<PagedResult<MinimalAuthorDto>>> SearchAuthor([FromQuery] SearchRequest searchParams)
    {
        var result = SearchService.SearchAuthor(searchParams);
        return result;
    }
}
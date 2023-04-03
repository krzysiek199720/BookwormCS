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
    
    [HttpGet("series")]
    public async Task<ActionResult<PagedResult<MinimalDataDto>>> SearchSeries([FromQuery] SearchRequest searchParams)
    {
        var result = SearchService.SearchSeries(searchParams);
        return result;
    }
    
    [HttpGet("category")]
    public async Task<ActionResult<PagedResult<MinimalDataDto>>> SearchCategory([FromQuery] SearchRequest searchParams)
    {
        var result = SearchService.SearchCategory(searchParams);
        return result;
    }
}
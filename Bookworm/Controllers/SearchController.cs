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
        
        Response.AddPaginationHeader(new PaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages));
        
        return result;
    }
    
    [HttpGet("author")]
    public async Task<ActionResult<PagedResult<MinimalAuthorDto>>> SearchAuthor([FromQuery] SearchRequest searchParams)
    {
        var result = SearchService.SearchAuthor(searchParams);
        
        Response.AddPaginationHeader(new PaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages));
        
        return result;
    }
    
    [HttpGet("series")]
    public async Task<ActionResult<PagedResult<MinimalDataDto>>> SearchSeries([FromQuery] SearchRequest searchParams)
    {
        var result = SearchService.SearchSeries(searchParams);
        
        Response.AddPaginationHeader(new PaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages));
        
        return result;
    }
    
    [HttpGet("category")]
    public async Task<ActionResult<PagedResult<MinimalDataDto>>> SearchCategory([FromQuery] SearchRequest searchParams)
    {
        var result = SearchService.SearchCategory(searchParams);
        
        Response.AddPaginationHeader(new PaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages));
        
        return result;
    }
    
    [HttpGet("publisher")]
    public async Task<ActionResult<PagedResult<MinimalDataDto>>> SearchPublisher([FromQuery] SearchRequest searchParams)
    {
        var result = SearchService.SearchPublisher(searchParams);
        
        Response.AddPaginationHeader(new PaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages));
        
        return result;
    }
}
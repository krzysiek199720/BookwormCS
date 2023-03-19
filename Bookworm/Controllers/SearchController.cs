using Bookworm.Controllers.Services.Interfaces;
using Bookworm.DTO;
using Bookworm.DTO.Results;
using Bookworm.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm.Controllers;

public class SearchController : ApiBaseController
{
    public IBookService BookService { get; }

    public SearchController(IBookService bookService)
    {
        BookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<BookMinimalDto>>> Search([FromQuery] SearchRequest searchParams)
    {
        var result = BookService.Search(searchParams);
        return result;
    }
}
using Bookworm.Controllers.Services.Interfaces;
using Bookworm.DTO.Requests.Book;
using Bookworm.DTO.Results;
using Bookworm.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm.Controllers.Services;

public class BookController : ApiBaseController
{
    public IBookService BookService { get; }

    public BookController(IBookService bookService)
    {
        BookService = bookService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBook(int id)
    {
        var result = BookService.GetBookById(id);
        if (result == null)
            NotFound();

        return result;
    }

    [HttpPost]
    [Authorize(Policy = "RequireAdmin")]
    public async Task<ActionResult<BookDetailsDto>> CreateBook(BookDetailsRequest bookDetailsRequest)
    {
        var result = BookService.CreateBook(bookDetailsRequest);
        return Ok(result);
    }
    
    [HttpPut("{bookId:int}")]
    [Authorize(Policy = "RequireAdmin")]
    public async Task<ActionResult> UpdateBook(int bookId, BookDetailsRequest bookDetailsRequest)
    {
        var result = BookService.UpdateBook(bookId, bookDetailsRequest);
        if (!result)
            return NotFound();
        return NoContent();
    }
    
    [HttpPut("{bookId:int}/series")]
    [Authorize(Policy = "RequireAdmin")]
    public async Task<ActionResult> UpdateSeries(int bookId, BookSeriesUpdateRequest bookSeries)
    {
        var result = BookService.UpdateBookSeries(bookId, bookSeries);
        if (!result)
            return NotFound();
        return NoContent();
    }
    
    [HttpPut("{bookId:int}/publisher")]
    [Authorize(Policy = "RequireAdmin")]
    public async Task<ActionResult> UpdatePublisher(int bookId, BookPublisherUpdateRequest bookPublisher)
    {
        var result = BookService.UpdateBookPublisher(bookId, bookPublisher);
        if (!result)
            return NotFound();
        return NoContent();
    }
    
    [HttpPut("{bookId:int}/authors")]
    [Authorize(Policy = "RequireAdmin")]
    public async Task<ActionResult> UpdateAuthors(int bookId, BookAuthorsUpdateRequest bookAuthors)
    {
        var result = BookService.UpdateBookAuthors(bookId, bookAuthors);
        if (!result)
            return NotFound();
        return NoContent();
    }
    
    [HttpPut("{bookId:int}/categories")]
    [Authorize(Policy = "RequireAdmin")]
    public async Task<ActionResult> UpdateCategories(int bookId, BookCategoriesUpdateRequest bookCategories)
    {
        var result = BookService.UpdateBookCategories(bookId, bookCategories);
        if (!result)
            return NotFound();
        return NoContent();
    }
    
    [HttpPut("{bookId:int}/like")]
    [Authorize]
    public async Task<ActionResult> SetFanStatus(int bookId)
    {
        var result = BookService.SetBookFan(bookId, User.GetUserId());
        if (!result)
            return NotFound();
        return NoContent();
    }
    
    [HttpPut("{bookId:int}/unlike")]
    [Authorize]
    public async Task<ActionResult> UnsetFanStatus(int bookId)
    {
        var result = BookService.RemoveBookFan(bookId, User.GetUserId());
        if (!result)
            return NotFound();
        return NoContent();
    }
}
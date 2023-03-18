using Bookworm.Controllers.Services.Interfaces;
using Bookworm.DTO.Results;
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
}
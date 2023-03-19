using Bookworm.DTO;
using Bookworm.DTO.Book;
using Bookworm.DTO.Results;
using Bookworm.Entities.BookData;
using Bookworm.Helpers;

namespace Bookworm.Controllers.Services.Interfaces;

public interface IBookService
{
    public BookDto GetBookById(int id);
    public PagedResult<BookMinimalDto> Search(SearchRequest searchParams);


    public BookDetailsDto CreateBook(BookDetailsRequest bookDetails);
}
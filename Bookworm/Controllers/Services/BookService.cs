using Bookworm.Controllers.Repositories.Interfaces;
using Bookworm.Controllers.Services.Interfaces;
using Bookworm.DTO.Results;
using Bookworm.Entities.BookData;
using Bookworm.Extensions.ResultConverters;

namespace Bookworm.Controllers.Services;

public class BookService : IBookService
{
    public IBookRepository BookRepository { get; }

    public BookService(IBookRepository bookRepository)
    {
        BookRepository = bookRepository;
    }
    
    public BookDto GetBookById(int id)
    {
        var result = BookRepository.GetBookWithIncludes(id);
        if (result == null) return null;

        return result.ToBookDto();
    }
}
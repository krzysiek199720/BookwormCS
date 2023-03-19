using System.Text;
using Bookworm.Controllers.Repositories.Interfaces;
using Bookworm.Controllers.Services.Interfaces;
using Bookworm.DTO;
using Bookworm.DTO.Book;
using Bookworm.DTO.Results;
using Bookworm.Entities.BookData;
using Bookworm.Extensions.ResultConverters;
using Bookworm.Helpers;
using Microsoft.EntityFrameworkCore;

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

    public PagedResult<BookMinimalDto> Search(SearchRequest searchParams)
    {
        var itemsToCompare = searchParams.SearchString.Split(null);

        var booKQueryable = BookRepository.GetBookQueryable();
        booKQueryable = booKQueryable.Where(x =>
                itemsToCompare.Any(c => x.Title.Contains(c))
                || itemsToCompare.Any(c => x.ISBN.Contains(c))
                || itemsToCompare.Any(c => x.Series.Name.Contains(c))
                || itemsToCompare.Any(c => x.Publisher.Name.Contains(c))
                || itemsToCompare.Any(c => x.Authors.Any(a => a.LastName.Contains(c) || a.FirstName.Contains(c)))
                || itemsToCompare.Any(c => x.Categories.Any(cat => cat.Name.Contains(c)))
            );
        booKQueryable.Include(x => x.Authors);

        var resultQuery = booKQueryable.Distinct().Select(x => x.ToMinimalBookDto());

        return PagedResult<BookMinimalDto>.CreatePagedResult(resultQuery, searchParams.PageNumber, searchParams.PageSize);
    }


    public BookDetailsDto CreateBook(BookDetailsRequest bookDetails)
    {
        var book = new Book
        {
            Title = bookDetails.Title,
            PageCount = bookDetails.PageCount,
            ISBN = bookDetails.ISBN,
            About = bookDetails.About,
            ReleaseYear = bookDetails.ReleaseYear,
            CoverUrl = bookDetails.CoverUrl,
        };

        BookRepository.CreateBook(book);
        BookRepository.SaveChanges();

        return book.ToBookDetailsDto();
    }
}
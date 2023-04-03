using Bookworm.DTO;
using Bookworm.DTO.Requests.Book;
using Bookworm.DTO.Results;
using Bookworm.Entities.Auth;
using Bookworm.Entities.BookData;
using Bookworm.Helpers;

namespace Bookworm.Controllers.Services.Interfaces;

public interface IBookService
{
    public BookDto GetBookById(int id);

    public BookDetailsDto CreateBook(BookDetailsRequest bookDetails);
    public bool UpdateBook(int bookId, BookDetailsRequest bookDetails);
    public bool UpdateBookSeries(int bookId, BookSeriesUpdateRequest bookSeriesUpdateRequest);
    public bool UpdateBookPublisher(int bookId, BookPublisherUpdateRequest bookPublisher);
    public bool UpdateBookAuthors(int bookId, BookAuthorsUpdateRequest bookAuthors);
    public bool UpdateBookCategories(int bookId, BookCategoriesUpdateRequest bookCategories);

    public bool SetBookFan(int bookId, string userId);
    public bool RemoveBookFan(int bookId, string userId);
}
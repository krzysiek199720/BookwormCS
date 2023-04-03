using System.Text;
using Bookworm.Controllers.Repositories.Interfaces;
using Bookworm.Controllers.Services.Interfaces;
using Bookworm.DTO;
using Bookworm.DTO.Requests.Book;
using Bookworm.DTO.Results;
using Bookworm.Entities.Auth;
using Bookworm.Entities.BookData;
using Bookworm.Extensions.ResultConverters;
using Bookworm.Helpers;
using Microsoft.EntityFrameworkCore;
using HostingEnvironmentExtensions = Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions;

namespace Bookworm.Controllers.Services;

public class BookService : IBookService
{
    public IBookRepository BookRepository { get; }
    public ISeriesRepository SeriesRepository { get; }
    public IPublisherRepository PublisherRepository { get; }
    public IAuthorRepository AuthorRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IAuthService AuthService { get; }

    public BookService(IBookRepository bookRepository,
        ISeriesRepository seriesRepository,
        IPublisherRepository publisherRepository,
        IAuthorRepository authorRepository,
        ICategoryRepository categoryRepository, 
        IAuthService authService
    )
    {
        BookRepository = bookRepository;
        SeriesRepository = seriesRepository;
        PublisherRepository = publisherRepository;
        AuthorRepository = authorRepository;
        CategoryRepository = categoryRepository;
        AuthService = authService;
    }
    
    public BookDto GetBookById(int id)
    {
        var result = BookRepository.GetBookWithIncludes(id);
        if (result == null) return null;

        return result.ToBookDto();
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
    
    public bool UpdateBook(int bookId, BookDetailsRequest bookDetails)
    {
        var book = BookRepository.Get(bookId);
        if (book == null) return false;
        
        book.Title = bookDetails.Title;
        book.PageCount = bookDetails.PageCount;
        book.ISBN = bookDetails.ISBN;
        book.About = bookDetails.About;
        book.ReleaseYear = bookDetails.ReleaseYear;
        book.CoverUrl = bookDetails.CoverUrl;

        BookRepository.SaveChanges();

        return true;
    }

    public bool UpdateBookSeries(int bookId, BookSeriesUpdateRequest bookSeriesUpdateRequest)
    {
        var book = BookRepository.Get(bookId);
        if (book == null) return false;
        var series = SeriesRepository.Get(bookSeriesUpdateRequest.SeriesId);
        if (series == null) return false;

        book.Series = series;

        BookRepository.SaveChanges();
        
        return true;
    }
    
    public bool UpdateBookPublisher(int bookId, BookPublisherUpdateRequest bookPublisherUpdateRequest)
    {
        var book = BookRepository.Get(bookId);
        if (book == null) return false;
        var publisher = PublisherRepository.Get(bookPublisherUpdateRequest.PublisherId);
        if (publisher == null) return false;

        book.Publisher = publisher;

        BookRepository.SaveChanges();
        
        return true;
    }
    
    public bool UpdateBookAuthors(int bookId, BookAuthorsUpdateRequest bookAuthors)
    {
        var book = BookRepository.Get(bookId);
        if (book == null) return false;
        var authors = AuthorRepository.FindAll(bookAuthors.AuthorIds);
        if (authors.Count() != bookAuthors.AuthorIds.Count) return false;

        book.Authors = authors.ToList();

        BookRepository.SaveChanges();
        
        return true;
    }
    
    public bool UpdateBookCategories(int bookId, BookCategoriesUpdateRequest bookCategories)
    {
        var book = BookRepository.Get(bookId);
        if (book == null) return false;
        var categories = CategoryRepository.FindAll(bookCategories.AuthorIds);
        if (categories.Count() != bookCategories.AuthorIds.Count) return false;

        book.Categories = categories.ToList();

        BookRepository.SaveChanges();
        
        return true;
    }

    public bool SetBookFan(int bookId, string userId)
    {
        var user = AuthService.Get(userId);
        if (user == null) return false;
        var book = BookRepository.Get(bookId);
        if (book == null) return false;

        book.Fans.Add(user);

        BookRepository.SaveChanges();
        return true;
    }
    
    public bool RemoveBookFan(int bookId, string userId)
    {
        var user = AuthService.Get(userId);
        if (user == null) return false;
        var book = BookRepository.Get(bookId);
        if (book == null) return false;

        book.Fans.Remove(user);

        BookRepository.SaveChanges();
        return true;
    }
}
using System.Text;
using Bookworm.Controllers.Repositories.Interfaces;
using Bookworm.Controllers.Services.Interfaces;
using Bookworm.DTO;
using Bookworm.DTO.Requests.Book;
using Bookworm.DTO.Results;
using Bookworm.Entities.BookData;
using Bookworm.Extensions.ResultConverters;
using Bookworm.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.Controllers.Services;

public class SearchService : ISearchService
{
    public IBookRepository BookRepository { get; }
    public ISeriesRepository SeriesRepository { get; }
    public IPublisherRepository PublisherRepository { get; }
    public IAuthorRepository AuthorRepository { get; }
    public ICategoryRepository CategoryRepository { get; }

    public SearchService(IBookRepository bookRepository,
        ISeriesRepository seriesRepository,
        IPublisherRepository publisherRepository,
        IAuthorRepository authorRepository,
        ICategoryRepository categoryRepository
        )
    {
        BookRepository = bookRepository;
        SeriesRepository = seriesRepository;
        PublisherRepository = publisherRepository;
        AuthorRepository = authorRepository;
        CategoryRepository = categoryRepository;
    }

    public PagedResult<BookMinimalDto> SearchBook(SearchRequest searchParams)
    {
        var itemsToCompare = searchParams.SearchString.Split(null);

        var booKQueryable = BookRepository.GetQueryable();
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

    public PagedResult<MinimalAuthorDto> SearchAuthor(SearchRequest searchParams)
    {
        var itemsToCompare = searchParams.SearchString.Split(null);

        var queryable = AuthorRepository.GetQueryable();
        queryable = queryable.Where(x =>
            itemsToCompare.Any(c => x.FirstName.Contains(c))
            || itemsToCompare.Any(c => x.LastName.Contains(c))
            || itemsToCompare.Any(c => x.Books.Any(b => b.Title.Contains(c)))
            || itemsToCompare.Any(c => x.Books.Any(b => b.Series.Name.Contains(c)))
        );

        var resultQuery = queryable.Distinct().Select(x => x.ToMinimalDto());

        return PagedResult<MinimalAuthorDto>.CreatePagedResult(resultQuery, searchParams.PageNumber, searchParams.PageSize);
    }

    public PagedResult<MinimalDataDto> SearchSeries(SearchRequest searchParams)
    {
        var itemsToCompare = searchParams.SearchString.Split(null);

        var queryable = SeriesRepository.GetQueryable();
        queryable = queryable.Where(x =>
            itemsToCompare.Any(c => x.Name.Contains(c))
            || itemsToCompare.Any(c => x.Books.Any(b => b.Title.Contains(c)))
            || itemsToCompare.Any(c => x. Books.Any(b => b.Authors.Any(a => a.FirstName.Contains(c) || a.LastName.Contains(c))))
        );

        var resultQuery = queryable.Distinct().Select(x => x.ToMinimalDto());

        return PagedResult<MinimalDataDto>.CreatePagedResult(resultQuery, searchParams.PageNumber, searchParams.PageSize);
    }
    
    public PagedResult<MinimalDataDto> SearchCategory(SearchRequest searchParams)
    {
        var itemsToCompare = searchParams.SearchString.Split(null);

        var queryable = SeriesRepository.GetQueryable();
        queryable = queryable.Where(x =>
            itemsToCompare.Any(c => x.Name.Contains(c))
        );

        var resultQuery = queryable.Distinct().Select(x => x.ToMinimalDto());

        return PagedResult<MinimalDataDto>.CreatePagedResult(resultQuery, searchParams.PageNumber, searchParams.PageSize);
    }

    public PagedResult<MinimalDataDto> SearchPublisher(SearchRequest searchParams)
    {
        var itemsToCompare = searchParams.SearchString.Split(null);

        var queryable = PublisherRepository.GetQueryable();
        queryable = queryable.Where(x =>
            itemsToCompare.Any(c => x.Name.Contains(c))
            || itemsToCompare.Any(c => x.Books.Any(b => b.Title.Contains(c)))
            || itemsToCompare.Any(c => x.Books.Any(b => b.Series.Name.Contains(c)))
        );

        var resultQuery = queryable.Distinct().Select(x => x.ToMinimalDto());

        return PagedResult<MinimalDataDto>.CreatePagedResult(resultQuery, searchParams.PageNumber, searchParams.PageSize);
    }
}
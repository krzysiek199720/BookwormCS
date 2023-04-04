using Bookworm.DTO;
using Bookworm.DTO.Requests.Book;
using Bookworm.DTO.Results;
using Bookworm.Entities.BookData;
using Bookworm.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm.Controllers.Services.Interfaces;

public interface ISearchService
{
    public PagedResult<BookMinimalDto> SearchBook(SearchRequest searchParams);
    public PagedResult<MinimalAuthorDto> SearchAuthor(SearchRequest searchParams);
    public PagedResult<MinimalDataDto> SearchSeries(SearchRequest searchParams);
    public PagedResult<MinimalDataDto> SearchCategory(SearchRequest searchParams);
    public PagedResult<MinimalDataDto> SearchPublisher(SearchRequest searchParams);
}
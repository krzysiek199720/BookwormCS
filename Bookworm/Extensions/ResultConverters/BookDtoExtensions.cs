using Bookworm.DTO.Results;
using Bookworm.Entities.Auth;
using Bookworm.Entities.BookData;

namespace Bookworm.Extensions.ResultConverters;

public static class BookDtoExtensions
{
    public static BookDto ToBookDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            PageCount = book.PageCount,
            ISBN = book.ISBN,
            About = book.About,
            ReleaseYear = book.ReleaseYear,
            CoverUrl = book.CoverUrl,
            Authors = book.Authors.Select(x => new MinimalDataDto{Id = x.Id, Name = string.IsNullOrEmpty(x.FirstName) ? x.LastName : $"{x.FirstName} {x.LastName}"}),
            Categories = book.Categories.Select(x => new MinimalDataDto{Id = x.Id, Name = x.Name}),
            Series = new MinimalDataDto{Id = book.SeriesId, Name = book.Series.Name},
            Publisher = new MinimalDataDto{Id = book.PublisherId, Name = book.Publisher.Name},
            FanCount = book.Fans.Count(),
        };
    }
    public static BookMinimalDto ToMinimalBookDto(this Book book)
    {
        return new BookMinimalDto
        {
            Id = book.Id,
            Title = book.Title,
            ReleaseYear = book.ReleaseYear,
            CoverUrl = book.CoverUrl,
            Authors = book.Authors.Select(x => new MinimalDataDto{Id = x.Id, Name = string.IsNullOrEmpty(x.FirstName) ? x.LastName : $"{x.FirstName} {x.LastName}"}),
        };
    }
    
    public static BookDetailsDto ToBookDetailsDto(this Book book)
    {
        return new BookDetailsDto
        {
            Id = book.Id,
            Title = book.Title,
            PageCount = book.PageCount,
            ISBN = book.ISBN,
            About = book.About,
            ReleaseYear = book.ReleaseYear,
            CoverUrl = book.CoverUrl,
        };
    }
}
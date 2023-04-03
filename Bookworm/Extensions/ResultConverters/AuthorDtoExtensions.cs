using Bookworm.DTO.Results;
using Bookworm.Entities.Auth;
using Bookworm.Entities.BookData;

namespace Bookworm.Extensions.ResultConverters;

public static class AuthorDtoExtensions
{
   public static MinimalAuthorDto ToMinimalDto(this Author author)
    {
        return new MinimalAuthorDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            PhotoUrl = author.PhotoUrl,
        };
    }
}
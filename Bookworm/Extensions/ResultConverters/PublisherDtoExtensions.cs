using Bookworm.DTO.Results;
using Bookworm.Entities.Auth;
using Bookworm.Entities.BookData;

namespace Bookworm.Extensions.ResultConverters;

public static class PublisherDtoExtensions
{
   public static MinimalDataDto ToMinimalDto(this Publisher publisher)
    {
        return new MinimalDataDto
        {
            Id = publisher.Id,
            Name = publisher.Name,
        };
    }
}
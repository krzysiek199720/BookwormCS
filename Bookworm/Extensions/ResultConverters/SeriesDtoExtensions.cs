using Bookworm.DTO.Results;
using Bookworm.Entities.Auth;
using Bookworm.Entities.BookData;

namespace Bookworm.Extensions.ResultConverters;

public static class SeriesDtoExtensions
{
   public static MinimalDataDto ToMinimalDto(this Series series)
    {
        return new MinimalDataDto
        {
            Id = series.Id,
            Name = series.Name,
        };
    }
}
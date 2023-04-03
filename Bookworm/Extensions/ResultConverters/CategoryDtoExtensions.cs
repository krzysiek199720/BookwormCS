using Bookworm.DTO.Results;
using Bookworm.Entities.Auth;
using Bookworm.Entities.BookData;

namespace Bookworm.Extensions.ResultConverters;

public static class CategoryDtoExtensions
{
   public static MinimalDataDto ToMinimalDto(this Category category)
    {
        return new MinimalDataDto
        {
            Id = category.Id,
            Name = category.Name,
        };
    }
}
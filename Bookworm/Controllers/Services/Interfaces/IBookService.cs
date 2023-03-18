using Bookworm.DTO.Results;
using Bookworm.Entities.BookData;

namespace Bookworm.Controllers.Services.Interfaces;

public interface IBookService
{
    public BookDto GetBookById(int id);
}
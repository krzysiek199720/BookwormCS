using Bookworm.Entities.BookData;

namespace Bookworm.Controllers.Repositories.Interfaces;

public interface IBookRepository
{
    public Book GetBookWithIncludes(int id);
}
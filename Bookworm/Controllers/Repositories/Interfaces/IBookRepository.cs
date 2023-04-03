using Bookworm.Entities.BookData;

namespace Bookworm.Controllers.Repositories.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    public Book GetBookWithIncludes(int id);

    public void CreateBook(Book book);
}
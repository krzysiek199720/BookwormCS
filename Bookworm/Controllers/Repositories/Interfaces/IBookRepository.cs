using Bookworm.Entities.BookData;

namespace Bookworm.Controllers.Repositories.Interfaces;

public interface IBookRepository : IRepository
{
    public Book GetBookWithIncludes(int id);
    public IQueryable<Book> GetBookQueryable();
    
    public void CreateBook(Book book);
}
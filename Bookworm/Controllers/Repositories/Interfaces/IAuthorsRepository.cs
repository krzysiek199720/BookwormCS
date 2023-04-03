using Bookworm.Entities.BookData;

namespace Bookworm.Controllers.Repositories.Interfaces;

public interface IAuthorRepository : IRepository<Author>
{
    public IQueryable<Author> FindAll(IEnumerable<int> ids);
}
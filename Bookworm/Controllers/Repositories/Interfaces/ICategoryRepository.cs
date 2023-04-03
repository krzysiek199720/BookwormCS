using Bookworm.Entities.BookData;

namespace Bookworm.Controllers.Repositories.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    public IQueryable<Category> FindAll(IEnumerable<int> ids);
}
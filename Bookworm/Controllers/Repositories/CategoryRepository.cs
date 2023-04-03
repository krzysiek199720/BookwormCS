using Bookworm.Controllers.Repositories.Interfaces;
using Bookworm.Data;
using Bookworm.Entities.BookData;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.Controllers.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public DataContext Context { get; }

    public CategoryRepository(DataContext context)
    {
        Context = context;
    }

    public Category Get(int id)
    {
        return Context.Categories.FirstOrDefault(x => x.Id == id);
    }

    public int SaveChanges()
    {
        return Context.SaveChanges();
    }

    public IQueryable<Category> GetQueryable()
    {
        return Context.Categories.AsQueryable();
    }

    public IQueryable<Category> FindAll(IEnumerable<int> ids)
    {
        return Context.Categories.AsQueryable().Where(x => ids.Contains(x.Id));
    }
}
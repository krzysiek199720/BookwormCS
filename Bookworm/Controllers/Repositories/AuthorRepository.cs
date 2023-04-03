using Bookworm.Controllers.Repositories.Interfaces;
using Bookworm.Data;
using Bookworm.Entities.BookData;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.Controllers.Repositories;

public class AuthorRepository : IAuthorRepository
{
    public DataContext Context { get; }

    public AuthorRepository(DataContext context)
    {
        Context = context;
    }

    public Author Get(int id)
    {
        return Context.Authors.FirstOrDefault(x => x.Id == id);
    }

    public int SaveChanges()
    {
        return Context.SaveChanges();
    }

    public IQueryable<Author> GetQueryable()
    {
        return Context.Authors.AsQueryable();
    }

    public IQueryable<Author> FindAll(IEnumerable<int> ids)
    {
        return Context.Authors.AsQueryable().Where(x => ids.Contains(x.Id));
    }
}
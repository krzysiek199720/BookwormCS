using Bookworm.Controllers.Repositories.Interfaces;
using Bookworm.Data;
using Bookworm.Entities.BookData;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.Controllers.Repositories;

public class PublisherRepository : IPublisherRepository
{
    public DataContext Context { get; }

    public PublisherRepository(DataContext context)
    {
        Context = context;
    }

    public Publisher Get(int id)
    {
        return Context.Publishers.FirstOrDefault(x => x.Id == id);
    }

    public int SaveChanges()
    {
        return Context.SaveChanges();
    }

    public IQueryable<Publisher> GetQueryable()
    {
        return Context.Publishers.AsQueryable();
    }
}
using Bookworm.Controllers.Repositories.Interfaces;
using Bookworm.Data;
using Bookworm.Entities.BookData;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.Controllers.Repositories;

public class SeriesRepository : ISeriesRepository
{
    public DataContext Context { get; }

    public SeriesRepository(DataContext context)
    {
        Context = context;
    }

    public Series Get(int id)
    {
        return Context.Series.FirstOrDefault(x => x.Id == id);
    }

    public int SaveChanges()
    {
        return Context.SaveChanges();
    }

    public IQueryable<Series> GetQueryable()
    {
        return Context.Series.AsQueryable();
    }


}
namespace Bookworm.Controllers.Repositories.Interfaces;

public interface IRepository<T>
{
    public int SaveChanges();
    public T Get(int id);
    public IQueryable<T> GetQueryable();
}
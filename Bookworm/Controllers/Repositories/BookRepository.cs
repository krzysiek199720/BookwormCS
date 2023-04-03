using Bookworm.Controllers.Repositories.Interfaces;
using Bookworm.Data;
using Bookworm.Entities.BookData;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.Controllers.Repositories;

public class BookRepository : IBookRepository
{
    public DataContext Context { get; }

    public BookRepository(DataContext context)
    {
        Context = context;
    }


    public Book GetBookWithIncludes(int id)
    {
        return Context.Books
            .Include(x => x.Authors)
            .Include(x => x.Categories)
            .Include(x => x.Series)
            .Include(x => x.Publisher)
            .FirstOrDefault(x => x.Id == id);
    }

    public Book Get(int id)
    {
        return Context.Books.FirstOrDefault(x => x.Id == id);
    }

    public IQueryable<Book> GetQueryable()
    {
        return Context.Books.AsQueryable();
    }


    public void CreateBook(Book book)
    {
        
        
        Context.Books.Add(book);
    }

    public int SaveChanges()
    {
        return Context.SaveChanges();
    }
}
using Bookworm.Entities.Auth;

namespace Bookworm.Entities.BookData;

public class Series
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string About { get; set; }

    public virtual IQueryable<Book> Books { get; set; }
    public virtual IQueryable<AppUser> Fans { get; set; }
    
}
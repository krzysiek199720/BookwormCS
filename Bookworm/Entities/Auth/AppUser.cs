using Bookworm.Entities.BookData;
using Microsoft.AspNetCore.Identity;

namespace Bookworm.Entities.Auth;

public class AppUser : IdentityUser
{
    public virtual IQueryable<Book> LikedBooks { get; set; }
    public virtual IQueryable<Series> LikedSeries { get; set; }
}
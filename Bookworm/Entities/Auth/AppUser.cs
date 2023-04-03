using Bookworm.Entities.BookData;
using Microsoft.AspNetCore.Identity;

namespace Bookworm.Entities.Auth;

public class AppUser : IdentityUser
{
    public virtual ICollection<Book> LikedBooks { get; set; }
    public virtual ICollection<Series> LikedSeries { get; set; }
}
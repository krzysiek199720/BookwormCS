using Bookworm.Entities.Auth;

namespace Bookworm.Entities.BookData;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string ISBN { get; set; }
    public string About { get; set; }
    public int ReleaseYear { get; set; }
    public string CoverUrl { get; set; }

    public int SeriesId { get; set; }
    public int SeriesOrder { get; set; }
    public int PublisherId { get; set; }
    
    public Series Series { get; set; }
    public Publisher Publisher { get; set; }

    public virtual ICollection<Author> Authors { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<AppUser> Fans { get; set; }
}
namespace Bookworm.Entities.BookData;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string About { get; set; }

    public virtual ICollection<Book> Books { get; set; }
}
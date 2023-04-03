namespace Bookworm.Entities.BookData;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set;}
    public DateOnly DateOfBirth { get; set;}
    public DateOnly DateOfDeath { get; set;}
    public string About { get; set;}
    public string PhotoUrl { get; set;}
    
    public virtual ICollection<Book> Books { get; set; }
}
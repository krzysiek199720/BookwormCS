namespace Bookworm.DTO.Results;

public class BookDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string ISBN { get; set; }
    public string About { get; set; }
    public int? ReleaseYear { get; set; }
    public string CoverUrl { get; set; }
}
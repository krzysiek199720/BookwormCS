namespace Bookworm.DTO.Results;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string ISBN { get; set; }
    public string About { get; set; }
    public int? ReleaseYear { get; set; }
    public string CoverUrl { get; set; }

    public IEnumerable<MinimalDataDto> Authors { get; set; }
    public IEnumerable<MinimalDataDto> Categories { get; set; }
    public MinimalDataDto Series { get; set; }
    public MinimalDataDto Publisher { get; set; }

    public int FanCount { get; set; }
}
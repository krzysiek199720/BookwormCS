namespace Bookworm.DTO.Results;

public class BookMinimalDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public string CoverUrl { get; set; }
    public IEnumerable<MinimalDataDto> Authors { get; set; }
}
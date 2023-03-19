namespace Bookworm.DTO;

public class SearchRequest : PaginationParams
{
    public string SearchString { get; set; }
}
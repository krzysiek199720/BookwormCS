namespace Bookworm.Helpers;

public class PagedResult<T> : List<T>
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public PagedResult(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        CurrentPage = pageNumber;
        TotalCount = count;
        PageSize = pageSize;
        TotalPages = TotalCount / PageSize;
        AddRange(items);
    }

    public static PagedResult<T> CreatePagedResult(IQueryable<T> queryable, int pageNumber, int pageSize)
    {
        var count = queryable.Count();

        queryable = queryable.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return new PagedResult<T>(queryable.ToList(), count, pageNumber, pageSize);
    }
}
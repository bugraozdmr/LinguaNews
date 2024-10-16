namespace BuildingBlocks.Pagination;

public class PaginatedResult<TEntity>
    where TEntity : class
{
    public int PageIndex { get; }
    public int PageSize { get; }
    public string? Query { get; }
    public long Count { get; }
    public IEnumerable<TEntity> Data { get; }

    // Constructor
    public PaginatedResult(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data, string? query = null)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
        Data = data;
        Query = query;
    }
}

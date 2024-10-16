namespace BuildingBlocks.Pagination;

public record PaginationRequest(string? query,int pageindex = 0, int pagesize = 10);
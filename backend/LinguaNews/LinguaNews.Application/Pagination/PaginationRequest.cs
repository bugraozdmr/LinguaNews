namespace LinguaNews.Application.Pagination;

public record PaginationRequest(string? query,int? category,int pageindex = 0, int pagesize = 10);
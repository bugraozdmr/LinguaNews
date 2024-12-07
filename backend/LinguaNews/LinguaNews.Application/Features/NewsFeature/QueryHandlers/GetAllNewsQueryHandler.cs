using LinguaNews.Application.CQRS;
using LinguaNews.Application.Data;
using LinguaNews.Application.Dtos.Responses.News;
using LinguaNews.Application.Features.NewsFeature.Queries;
using LinguaNews.Application.Pagination;
using Microsoft.EntityFrameworkCore;

namespace LinguaNews.Application.Features.NewsFeature.QueryHandlers;

public class GetAllNewsQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetAllNewsQuery,GetAllNewsResponseDto>
{
    public async Task<GetAllNewsResponseDto> Handle(GetAllNewsQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.pageindex < 0 ? 0 : query.PaginationRequest.pageindex;
        var pageSize = query.PaginationRequest.pagesize < 1 ? 10 : (query.PaginationRequest.pagesize > 10 ? 10 : query.PaginationRequest.pagesize);

        var search_param = query.PaginationRequest.query?.ToLower() ?? "";
        var category_param = query.PaginationRequest.category;

        
        var totalCount = await dbContext.News
            .Where(n => (string.IsNullOrWhiteSpace(search_param) || n.Title.ToLower().Contains(search_param)) &&
                        (!category_param.HasValue || n.CategoryId == category_param.Value))
            .LongCountAsync(cancellationToken);
        
        var news = await dbContext.News
            .Include(n => n.Category)
            .Where(n => (string.IsNullOrWhiteSpace(search_param) || n.Title.ToLower().Contains(search_param)) &&
                        (!category_param.HasValue || n.CategoryId == category_param.Value))
            .OrderBy(n => n.LastModified)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .Select(n => new GetAllNewsResponse
            {
                Title = n.Title,
                Slug = n.Slug,
                Image = n.Image,
                CategoryId = n.CategoryId,
                Category = n.Category,
                CreatedAt = n.CreatedAt,
                Intermediate = n.Intermediate,
                Beginner = n.Beginner,
                Advanced = n.Advanced
            })
            .ToListAsync(cancellationToken);

        return new GetAllNewsResponseDto
        (
            new PaginatedResult<GetAllNewsResponse>
            (
                pageIndex,
                pageSize,
                totalCount,
                news
            )
        );
    }
}
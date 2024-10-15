using BuildingBlocks.CQRS;
using LinguaNews.Application.Data;
using LinguaNews.Application.Dtos.Responses.Category;
using LinguaNews.Application.Features.CategoryFeature.Queries;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace LinguaNews.Application.Features.CategoryFeature.QueryHandlers;

public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, List<GetAllCategoriesResponseDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetAllCategoriesQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetAllCategoriesResponseDto>> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
    {
        var categories = await _dbContext.Categories
            .ToListAsync(cancellationToken);

        var categoriesDto = categories.Adapt<List<GetAllCategoriesResponseDto>>();

        return categoriesDto;
    }
}
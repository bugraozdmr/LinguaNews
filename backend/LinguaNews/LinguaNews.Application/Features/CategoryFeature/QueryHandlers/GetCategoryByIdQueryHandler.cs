using LinguaNews.Application.CQRS;
using LinguaNews.Application.Data;
using LinguaNews.Application.Dtos.Responses.Category;
using LinguaNews.Application.Exceptions;
using LinguaNews.Application.Features.CategoryFeature.Queries;
using LinguaNews.Domain.Models;
using Mapster;

namespace LinguaNews.Application.Features.CategoryFeature.QueryHandlers;

public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, GetCategoryByIdResponseDto>
{
    private readonly IApplicationDbContext _dbContext;

    public GetCategoryByIdQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetCategoryByIdResponseDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FindAsync(new object[] { request.Id }, cancellationToken);

        if (category == null)
        {
            throw new EntityNotFoundException<Category>(request.Id,new Category());
        }

        var categoryNew = category.Adapt<GetCategoryByIdResponseDto>();
        
        return categoryNew;
    }
}
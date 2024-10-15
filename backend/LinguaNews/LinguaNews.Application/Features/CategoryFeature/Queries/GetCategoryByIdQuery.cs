
using BuildingBlocks.CQRS;
using LinguaNews.Application.Dtos.Responses.Category;

namespace LinguaNews.Application.Features.CategoryFeature.Queries;

public record GetCategoryByIdQuery : IQuery<GetCategoryByIdResponseDto>
{
    public int Id { get; set; }
}
using LinguaNews.Application.CQRS;
using LinguaNews.Application.Dtos.Responses.Category;

namespace LinguaNews.Application.Features.CategoryFeature.Queries;

public record GetAllCategoriesQuery : IQuery<List<GetAllCategoriesResponseDto>>
{
}
using LinguaNews.Application.CQRS;
using LinguaNews.Application.Dtos.Responses.Category;

namespace LinguaNews.Application.Features.CategoryFeature.Commands;

public record DeleteCategoryCommand : ICommand<DeleteCategoryResponseDto>
{
    public int Id { get; set; }
}
using LinguaNews.Application.CQRS;
using LinguaNews.Application.Dtos.Responses.Category;

namespace LinguaNews.Application.Features.CategoryFeature.Commands;

public record UpdateCategoryCommand : ICommand<UpdateCategoryResponseDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}
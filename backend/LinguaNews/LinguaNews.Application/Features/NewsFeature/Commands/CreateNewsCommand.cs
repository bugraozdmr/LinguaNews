using LinguaNews.Application.CQRS;
using LinguaNews.Application.Dtos.Responses.News;

namespace LinguaNews.Application.Features.NewsFeature.Commands;

public record CreateNewsCommand : ICommand<CreateNewsResponseDto>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Intermediate { get; set; } = string.Empty;
    public string Beginner { get; set; } = string.Empty;
    public string Advanced { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CategoryId { get; set; }
}
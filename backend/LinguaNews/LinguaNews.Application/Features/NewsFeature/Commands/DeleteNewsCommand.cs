using BuildingBlocks.CQRS;
using LinguaNews.Application.Dtos.Responses.News;

namespace LinguaNews.Application.Features.NewsFeature.Commands;

public record DeleteNewsCommand : ICommand<DeleteNewsResponseDto>
{
    public Guid Id { get; set; }
}
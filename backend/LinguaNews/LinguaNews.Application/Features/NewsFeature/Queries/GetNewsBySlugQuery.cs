using LinguaNews.Application.CQRS;
using LinguaNews.Application.Dtos.Responses.News;

namespace LinguaNews.Application.Features.NewsFeature.Queries;

public record GetNewsBySlugQuery : IQuery<GetNewsBySlugResponseDto>
{
    public string Slug { get; set; }
}
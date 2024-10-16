using LinguaNews.Application.CQRS;
using LinguaNews.Application.Dtos.Responses.News;
using LinguaNews.Application.Pagination;

namespace LinguaNews.Application.Features.NewsFeature.Queries;

public record GetAllNewsQuery(PaginationRequest PaginationRequest) 
    : IQuery<GetAllNewsResponseDto>;

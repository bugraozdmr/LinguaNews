using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using LinguaNews.Application.Dtos.Responses.News;

namespace LinguaNews.Application.Features.NewsFeature.Queries;

public record GetAllNewsQuery(PaginationRequest PaginationRequest) 
    : IQuery<GetAllNewsResponseDto>;

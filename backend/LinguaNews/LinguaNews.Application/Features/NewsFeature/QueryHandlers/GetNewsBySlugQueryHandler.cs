using BuildingBlocks.CQRS;
using LinguaNews.Application.Data;
using LinguaNews.Application.Dtos.Responses.News;
using LinguaNews.Application.Exceptions;
using LinguaNews.Application.Features.NewsFeature.Queries;
using LinguaNews.Domain.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace LinguaNews.Application.Features.NewsFeature.QueryHandlers;

public class GetNewsBySlugQueryHandler : IQueryHandler<GetNewsBySlugQuery, GetNewsBySlugResponseDto>
{
    private readonly IApplicationDbContext _dbContext;

    public GetNewsBySlugQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<GetNewsBySlugResponseDto> Handle(GetNewsBySlugQuery request, CancellationToken cancellationToken)
    {
        var news = await _dbContext.News
            .Include(n => n.Category)
            .FirstOrDefaultAsync(n => n.Slug == request.Slug, cancellationToken);


        if (news == null)
        {
            // not id slug
            throw new EntityNotFoundException<News>(request.Slug,new News());
        }

        var newss = news.Adapt<GetNewsBySlugResponseDto>();
        
        return newss;
    }
}
using LinguaNews.Application.CQRS;
using LinguaNews.Application.Data;
using LinguaNews.Application.Dtos.Responses.News;
using LinguaNews.Application.Exceptions;
using LinguaNews.Application.Features.NewsFeature.Commands;
using LinguaNews.Domain.Models;

namespace LinguaNews.Application.Features.NewsFeature.CommandHandlers;

public class DeleteNewsCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteNewsCommand,DeleteNewsResponseDto>
{
    public async Task<DeleteNewsResponseDto> Handle(DeleteNewsCommand command, CancellationToken cancellationToken)
    {
        var news = await dbContext.News
            .FindAsync([command.Id], cancellationToken:cancellationToken);

        if (news == null)
            throw new EntityNotFoundException<News>(command.Id,new News());
        
        dbContext.News.Remove(news);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteNewsResponseDto(){Result = true};
    }
}
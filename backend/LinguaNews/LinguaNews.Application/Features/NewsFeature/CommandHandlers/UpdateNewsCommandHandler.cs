using LinguaNews.Application.CQRS;
using LinguaNews.Application.Data;
using LinguaNews.Application.Dtos.Responses.News;
using LinguaNews.Application.Exceptions;
using LinguaNews.Application.Features.NewsFeature.Commands;
using LinguaNews.Domain.Models;

namespace LinguaNews.Application.Features.NewsFeature.CommandHandlers;

public class UpdateNewsCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateNewsCommand, UpdateNewsResponseDto>
{
    public async Task<UpdateNewsResponseDto> Handle(UpdateNewsCommand command, CancellationToken cancellationToken)
    {
        var news = await dbContext.News.FindAsync([command.Id], cancellationToken: cancellationToken);

        if (news == null)
        {
            throw new EntityNotFoundException<News>(command.Id,new News());
        }
        
        var category = await dbContext.Categories.FindAsync(new object[] { command.CategoryId },cancellationToken);

        if (category == null)
            throw new CategoryNotExistException(command.CategoryId);
        
        UpdateNewsWithNewValues(news, command);
        
        dbContext.News.Update(news);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateNewsResponseDto()
        {
            Result = true
        };
    }
    
    public void UpdateNewsWithNewValues(News news, UpdateNewsCommand command)
    {
        var slug = CreateSlug(command.Title);
        
        news.Update(command.Title,slug,command.Image,command.CategoryId,
            command.Beginner,command.Intermediate,command.Advanced);
    }
    
    private string CreateSlug(string title)
    {
        title = title.ToLowerInvariant();

        title = title
            .Replace("ö", "o")
            .Replace("ü", "u")
            .Replace("ş", "s")
            .Replace("ı", "i")
            .Replace("ğ", "g")
            .Replace("ç", "c");

        title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", "");

        title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", "-").Trim('-');

        return title;
    }
}
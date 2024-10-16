using LinguaNews.Application.CQRS;
using LinguaNews.Application.Data;
using LinguaNews.Application.Dtos.Responses.News;
using LinguaNews.Application.Exceptions;
using LinguaNews.Application.Features.NewsFeature.Commands;
using LinguaNews.Domain.Models;

namespace LinguaNews.Application.Features.NewsFeature.CommandHandlers;

public class CreateNewsCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateNewsCommand,CreateNewsResponseDto>
{
    public async Task<CreateNewsResponseDto> Handle(CreateNewsCommand command, CancellationToken cancellationToken)
    {
        var category = await dbContext.Categories.FindAsync(new object[] { command.CategoryId },cancellationToken);

        if (category == null)
            throw new CategoryNotExistException(command.CategoryId);
        
        var news = CreateNewNews(command);
        
        dbContext.News.Add(news);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateNewsResponseDto()
        {
            Result = true
        };
    }
    
    private News CreateNewNews(CreateNewsCommand command)
    {
        var slug = CreateSlug(command.Title);
        
        var newNews = News.Create(null,command.Title
            ,slug,command.Image,command.CategoryId
            ,command.Beginner,command.Intermediate,command.Advanced);
        
        return newNews;
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
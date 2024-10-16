using LinguaNews.Application.CQRS;
using LinguaNews.Application.Data;
using LinguaNews.Application.Dtos.Responses.Category;
using LinguaNews.Application.Exceptions;
using LinguaNews.Application.Features.CategoryFeature.Commands;
using LinguaNews.Domain.Models;

namespace LinguaNews.Application.Features.CategoryFeature.CommandHandlers;

public class DeleteCategoryCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteCategoryCommand,DeleteCategoryResponseDto>
{
    public async Task<DeleteCategoryResponseDto> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await dbContext.Categories
            .FindAsync([command.Id], cancellationToken:cancellationToken);

        if (category == null)
            throw new EntityNotFoundException<Category>(command.Id,new Category());
        
        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteCategoryResponseDto{Result = true};
    }
}
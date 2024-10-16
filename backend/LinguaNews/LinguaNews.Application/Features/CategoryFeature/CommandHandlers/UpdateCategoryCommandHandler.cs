using LinguaNews.Application.CQRS;
using LinguaNews.Application.Data;
using LinguaNews.Application.Dtos.Responses.Category;
using LinguaNews.Application.Exceptions;
using LinguaNews.Application.Features.CategoryFeature.Commands;
using LinguaNews.Domain.Models;

namespace LinguaNews.Application.Features.CategoryFeature.CommandHandlers;

public class UpdateCategoryCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateCategoryCommand,UpdateCategoryResponseDto>
{
    public async Task<UpdateCategoryResponseDto> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await dbContext.Categories.FindAsync([command.Id], cancellationToken: cancellationToken);

        if (category == null)
        {
            throw new EntityNotFoundException<Category>(command.Id,new Category());
        }
        
        category = UpdateCategoryWithNewValues(category, command);
        
        dbContext.Categories.Update(category);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateCategoryResponseDto
        {
            Result = true
        };
    }

    public Category UpdateCategoryWithNewValues(Category category, UpdateCategoryCommand command)
    {
        category.Name = command.Name;
        category.Description = command.Description;
        category.Image = command.Image;
        
        return category;
    }
}
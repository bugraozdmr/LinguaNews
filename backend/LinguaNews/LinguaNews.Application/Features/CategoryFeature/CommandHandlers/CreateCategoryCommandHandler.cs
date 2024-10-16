using LinguaNews.Application.CQRS;
using LinguaNews.Application.Data;
using LinguaNews.Application.Dtos.Responses.Category;
using LinguaNews.Application.Features.CategoryFeature.Commands;
using LinguaNews.Domain.Models;

namespace LinguaNews.Application.Features.CategoryFeature.CommandHandlers;

public class CreateCategoryCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateCategoryCommand,CreateCategoryResponseDto>
{
    public async Task<CreateCategoryResponseDto> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = CreateNewCategory(command);
        
        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateCategoryResponseDto
        {
            Result = true
        };
    }

    private Category CreateNewCategory(CreateCategoryCommand command)
    {
        var newCategory = Category.Create(command.Name, command.Description,command.Image);
        
        return newCategory;
    }
}
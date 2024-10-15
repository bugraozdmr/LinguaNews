using FluentValidation;
using LinguaNews.Application.Features.CategoryFeature.Commands;

namespace LinguaNews.Application.Features.CategoryFeature.Validators;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name can't be null")
            .NotEmpty().WithMessage("Name can't be empty")
            .MinimumLength(3).WithMessage("Name can't exceed 3 characters");
        
        RuleFor(x => x.Description)
            .NotNull().WithMessage("Description can't be null")
            .NotEmpty().WithMessage("Description can't be empty")
            .MinimumLength(1).WithMessage("Description can't lower 1 characters").MaximumLength(40).WithMessage("Description can't exceed 40 characters");

        RuleFor(x => x.Image)
            .NotNull().WithMessage("Image can't be null")
            .NotEmpty().WithMessage("Image can't be empty");
    }
}
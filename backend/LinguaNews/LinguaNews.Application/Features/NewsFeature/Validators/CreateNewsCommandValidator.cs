using FluentValidation;
using LinguaNews.Application.Features.NewsFeature.Commands;

namespace LinguaNews.Application.Features.NewsFeature.Validators;

// kaydetmeyi unutma servislere FluentValidations
public class CreateNewsCommandValidator : AbstractValidator<CreateNewsCommand>
{
    public CreateNewsCommandValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(80);
        RuleFor(x => x.Advanced).NotNull().NotEmpty();
        RuleFor(x => x.Intermediate).NotNull().NotEmpty();
        RuleFor(x => x.Beginner).NotNull().NotEmpty();
        RuleFor(x => x.Image).NotNull().NotEmpty();
    }
}
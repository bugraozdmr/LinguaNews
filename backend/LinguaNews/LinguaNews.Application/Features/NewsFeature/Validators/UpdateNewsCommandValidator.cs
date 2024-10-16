using FluentValidation;
using LinguaNews.Application.Features.NewsFeature.Commands;

namespace LinguaNews.Application.Features.NewsFeature.Validators;

public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
{
    public UpdateNewsCommandValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(80);
        RuleFor(x => x.Advanced).NotNull().NotEmpty();
        RuleFor(x => x.Intermediate).NotNull().NotEmpty();
        RuleFor(x => x.Beginner).NotNull().NotEmpty();
        RuleFor(x => x.Image).NotNull().NotEmpty();
    }
}
using FluentValidation;
using LinguaNews.Application.CQRS;
using MediatR;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace LinguaNews.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    (IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults =
            await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures =
            validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

        // TODO : check if works
        if (failures.Any())
        {
            var errorMessages = string.Join(Environment.NewLine, failures.Select(f => f.ErrorMessage));
            throw new ValidationException(errorMessages);
        }

        return await next();
    }
}
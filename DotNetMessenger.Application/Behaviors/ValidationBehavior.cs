using DotNetMessenger.Application.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace DotNetMessenger.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
            return await next(cancellationToken);

        ValidationContext<TRequest> context = new(request);

        ValidationResult[] results = await Task.WhenAll(
            validators.Select(validator => validator.ValidateAsync(context, cancellationToken)));

        Dictionary<string, string[]> errors = results
            .SelectMany(result => result.Errors)
            .GroupBy(failure => failure.PropertyName)
            .ToDictionary(
                group => group.Key,
                group => group.Select(failure => failure.ErrorMessage).Distinct().ToArray());

        if (errors.Count != 0)
            throw new RequestValidationException(errors);

        return await next(cancellationToken);
    }
}

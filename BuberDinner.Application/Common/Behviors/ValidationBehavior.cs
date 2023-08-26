using MediatR;
using ErrorOr;
using FluentValidation;

namespace BuberDinner.Application.Common.Behviors;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse> // IRequest<> comes from MediatR
    where TResponse : IErrorOr // IErrorOr comes from ErrorOr library
{
    private readonly IValidator<TRequest>? _validator;

    // Each request in our solution can have either no validator or one validator.
    // This is why we use the ? operator to make the validator optional.
    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        // If there is no validator, the next delegate is invoked.
        // Otherwise, the validator is invoked.
        if (_validator is null)
        {
            return await next();
        }
        
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        
        // If there are no validation errors, the next delegate is invoked.
        // Otherwise, the handler is not invoked, and the
        // validation errors are returned to the caller.

        if (validationResult.IsValid)
        {
            return await next();
        }
        
        // Map the ValidationFailure objects to Error objects from the ErrorOr library:
        var errors = validationResult.Errors
            .ConvertAll(x => Error.Validation(
                x.PropertyName,
                x.ErrorMessage));
        // ConvertAll() is equivalent to ".Select().ToList()" in LINQ
        
        return (dynamic)errors; 
        
        // The dynamic keyword will check in run-time if the type of `errors` is compatible 
        // with the type of TResponse. If it is, it will cast it to that type.
        // If it is not, it will throw an exception.
    }
}
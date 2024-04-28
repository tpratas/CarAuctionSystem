using ErrorOr;
using FluentValidation;
using MediatR;

namespace CarAuctionSystem.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest> _validator;

    public ValidationBehaviour(IValidator<TRequest> validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        var validationResult = _validator.ValidateAsync(request, cancellationToken).Result;

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .Select(v => Error.Validation(v.PropertyName, v.ErrorMessage))
            .ToList();

        return (dynamic)errors;
    }
}

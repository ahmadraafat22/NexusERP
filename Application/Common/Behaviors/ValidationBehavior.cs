using FluentValidation;
using MediatR;

namespace NexusERP.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // check if we have validators or not (if there are no validator we will go to the next )
            if (_validators.Any())
            {
                // return the validation context to validate 
                var context = new ValidationContext<TRequest>(request);
                // this will return all results of validation operations 
                var validateResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                // check if the results have failures or not 
                var failures = validateResults
                    .SelectMany(r => r.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}

using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) 
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // check if we have validators already
            if (_validators.Any()) 
            {
                // return context from request to check it 
                var context = new ValidationContext<TRequest>(request);
                // return all error in each validator if validator have failures 
                var failures = ( await Task.WhenAll(_validators
                    .Select(v => v.ValidateAsync(context))
                    ))
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

using MediatR;
using System;
using FluentValidation;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Todos.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators; 

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators.Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null).ToList();
            
            if(failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}

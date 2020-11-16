using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Sandbox.MediatR.Behaviours.API.Controllers.Common;

namespace Sandbox.MediatR.Behaviours.API.Behaviours
{
    public class FailFastBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public FailFastBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next
        )
        {
            var errors = _validators
                .Select(e => e.Validate(request))
                .SelectMany(e => e.Errors)
                .Select(e => e.ErrorMessage)
                .Where(e => e != null)
                .ToList();

            if (errors.Any())
            {
                //Implement Domain Validations//Implement Domain Validations
                Validations.Create(errors);
                return default;
            }

            return await next();
        }
    }
}

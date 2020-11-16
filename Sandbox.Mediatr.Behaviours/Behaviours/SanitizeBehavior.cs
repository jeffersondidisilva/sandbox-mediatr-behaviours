using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sandbox.MediatR.Behaviours.API.Attributes.Common;

namespace Sandbox.MediatR.Behaviours.API.Behaviours
{
    public class SanitizeBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(
            TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next
        )
        {
            var properties = request.GetType()
                .GetProperties()
                .Where(e => e.GetCustomAttributes(typeof(SanitizeAttribute), true).Any())
                .ToList();

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute(typeof(SanitizeAttribute));
                var instance = Activator.CreateInstance(attribute!.GetType());
                var method = instance!.GetType().GetMethod("GetSanitizedValue");

                var result = method!.Invoke(instance, new[] { property.GetValue(request) });
                property.SetValue(request, result);
            }
            return await next();
        }
    }
}

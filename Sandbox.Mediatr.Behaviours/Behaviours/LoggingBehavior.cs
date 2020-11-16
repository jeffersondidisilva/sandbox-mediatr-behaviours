using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Sandbox.MediatR.Behaviours.API.Behaviours
{
    public class LoggingBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse>
    {

        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next
        )
        {
            var json = JsonConvert.SerializeObject(request, Formatting.Indented);
            _logger.LogInformation(json);
            return await next(); 
        }
    }
}

using Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Middleware
{
    public class ApiLogMiddleware : IMiddleware
    {
        private readonly ILogger<ApiLogMiddleware> _logger;
        private readonly ILogRepository _logRepository;

        public ApiLogMiddleware(ILogger<ApiLogMiddleware> logger, ILogRepository logRepository)
        {
            _logger = logger;
            _logRepository = logRepository;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}

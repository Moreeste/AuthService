using Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;

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

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            int statusCode;
            string? jsonResponse;

            string? jsonRequest = await ReadRequestBody(context.Request);
            string? path = context.Request.Path;
            string? method = context.Request.Method;
            string? ip = context.Connection.RemoteIpAddress?.ToString();
            string? token = context.Request.Headers.Authorization.ToString();
            
            var originalBodyStream = context.Request.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await next(context);

                jsonResponse = await ReadResponseBody(context.Response);
                statusCode = context.Response.StatusCode;

                context.Response.Body = originalBodyStream;
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();
            using var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true);
            var body = await reader.ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);
            return body;
        }

        private async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(response.Body, Encoding.UTF8, true, 1024, true);
            var body = await reader.ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return body;
        }
    }
}

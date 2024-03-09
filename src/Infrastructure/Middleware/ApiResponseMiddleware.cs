using Domain.Model.Response;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Infrastructure.Middleware
{
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;

                await _next(context);

                memoryStream.Seek(0, SeekOrigin.Begin);

                string responseBody = new StreamReader(memoryStream).ReadToEnd();
                var originalResponse = JsonConvert.DeserializeObject(responseBody);

                context.Response.Body = originalBodyStream;

                var headerTraceId = context.Response.Headers["TraceId"];
                string? traceId = (headerTraceId.Count > 0) ? headerTraceId[0] : string.Empty;

                var newResponse = new ResponseModel()
                {
                    Success = true,
                    TraceId = traceId,
                    Data = originalResponse,
                };

                var jsonResponse = JsonConvert.SerializeObject(newResponse);
                context.Response.Headers.Remove("TraceId");
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}

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

                var newResponse = new ResponseModel();

                if (context.Response.StatusCode == StatusCodes.Status200OK)
                {
                    newResponse.Success = true;
                    newResponse.TraceId = Guid.NewGuid().ToString().ToUpper();
                    newResponse.Result = originalResponse;

                    var jsonResponse = JsonConvert.SerializeObject(newResponse);
                    await context.Response.WriteAsync(jsonResponse);
                }
                else
                {
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);

                    if (errorResponse != null)
                    {
                        newResponse.Success = false;
                        newResponse.TraceId = errorResponse?.ErrorId;
                        newResponse.Error = errorResponse?.ErrorMessage;

                        var jsonResponse = JsonConvert.SerializeObject(newResponse);
                        await context.Response.WriteAsync(jsonResponse);
                    }
                }
            }
        }
    }
}

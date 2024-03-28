using Domain.Model.Response;
using Domain.Utilities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.Middleware
{
    public class ApiResponseMiddleware : IMiddleware
    {
        private readonly IUtilities _utilities;

        public ApiResponseMiddleware(IUtilities utilities)
        {
            _utilities = utilities;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var originalBodyStream = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;

                await next(context);

                memoryStream.Seek(0, SeekOrigin.Begin);

                string responseBody = new StreamReader(memoryStream).ReadToEnd();
                var originalResponse = JsonConvert.DeserializeObject(responseBody);

                context.Response.Body = originalBodyStream;

                var newResponse = new ResponseModel();

                if (context.Response.StatusCode == StatusCodes.Status200OK)
                {
                    newResponse.Success = true;
                    newResponse.TraceId = _utilities.GenerateId();
                    newResponse.Result = originalResponse;

                    var jsonResponse = JsonConvert.SerializeObject(newResponse, serializerSettings);
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

                        var jsonResponse = JsonConvert.SerializeObject(newResponse, serializerSettings);
                        await context.Response.WriteAsync(jsonResponse);
                    }
                }
            }
        }
    }
}

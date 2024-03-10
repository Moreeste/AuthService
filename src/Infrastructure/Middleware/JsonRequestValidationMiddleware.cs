using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using Domain.Exceptions;

namespace Infrastructure.Middleware
{
    public class JsonRequestValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public JsonRequestValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "POST" || context.Request.Method == "PUT")
            {
                string originalRequestBody = await GetRequestBody(context.Request);
                context.Request.Body = GenerateStreamFromString(originalRequestBody);

                if (!IsValidJson(originalRequestBody))
                {
                    throw new JsonRequestException();
                }
            }

            await _next(context);
        }

        private async Task<string> GetRequestBody(HttpRequest request)
        {
            using (var reader = new StreamReader(request.Body, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private bool IsValidJson(string json)
        {
            try
            {
                JToken.Parse(json);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }
    }
}

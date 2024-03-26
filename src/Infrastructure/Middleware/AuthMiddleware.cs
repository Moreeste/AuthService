using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middleware
{
    public class AuthMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
        }
    }
}

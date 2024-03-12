using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Middleware
{
    public static class ConfigureMiddlewares
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ApiResponseMiddleware>();
            builder.UseMiddleware<ErrorHandlingMiddleware>();
            builder.UseMiddleware<JsonRequestValidationMiddleware>();

            return builder;
        }
    }
}

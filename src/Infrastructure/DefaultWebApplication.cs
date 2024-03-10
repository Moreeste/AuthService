using Application;
using Infrastructure.Middleware;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Infrastructure
{
    public static class DefaultWebApplication
    {
        public static WebApplication Create(Action<WebApplicationBuilder>? webappBuilder = null)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();

            if (webappBuilder != null)
            {
                webappBuilder.Invoke(builder);
            }

            return builder.Build();
        }

        public static void Run(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDefaultSwagger();
            }

            app.UseMiddleware<ApiResponseMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<JsonRequestValidationMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}

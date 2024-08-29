using Domain.Repository;
using Domain.Services;
using Domain.Utilities;
using Infrastructure.Middleware;
using Infrastructure.Repository;
using Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ApiLogMiddleware>();
            services.AddTransient<ApiResponseMiddleware>();
            services.AddTransient<ErrorHandlingMiddleware>();
            services.AddTransient<AuthMiddleware>();

            services.AddScoped<IUtilities, Utilities>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ICatalogueRepository, CatalogueRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserPropertiesRepository, UserPropertiesRepository>();
            services.AddScoped<IPasswordRepository, PasswordRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IEndpointRepository, EndpointRepository>();
            services.AddScoped<IProfilePermissionRepository, ProfilePermissionRepository>();

            return services;
        }
    }
}

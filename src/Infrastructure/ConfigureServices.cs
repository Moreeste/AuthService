using Application.Auth.Services;
using Application.Profile.Services;
using Application.User.Services;
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
            services.AddTransient<ErrorHandlingMiddleware>();
            services.AddTransient<AuthMiddleware>();

            services.AddScoped<IUtilities, Utilities>();

            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ICatalogueRepository, CatalogueRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordRepository, PasswordRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();

            return services;
        }
    }
}

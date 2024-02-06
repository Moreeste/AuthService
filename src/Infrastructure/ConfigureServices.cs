using Application.Auth.Services;
using Application.Register.Services;
using Application.User.Services;
using Domain.Repository;
using Domain.Services;
using Infrastructure.Repository;
using Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordRepository, PasswordRepository>();

            return services;
        }
    }
}

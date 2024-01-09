using Application.Modules.Register.Services;
using Application.Modules.User.Services;
using Domain.Repository;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class CustomServices
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRegisterService, RegisterService>();

            return services;
        }
    }
}

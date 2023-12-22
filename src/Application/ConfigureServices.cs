using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ConfigureServices
    {
        public const string ApplicationName = "AuthService";

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ConfigureServices).Assembly;

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Application
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(Application).Assembly;

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}

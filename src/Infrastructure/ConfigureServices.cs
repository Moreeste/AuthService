using Infrastructure.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Conventions.Add(new ApiVersionConvention());
            });

            services.AddEndpointsApiExplorer();

            services.AddDefaultSwagger();

            return services;
        }
    }
}

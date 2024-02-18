using Infrastructure.Database;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddDatabase(configuration);

            services.AddCustomServices();

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

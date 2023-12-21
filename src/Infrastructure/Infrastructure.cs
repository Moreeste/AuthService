using Infrastructure.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Infrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Conventions.Add(new ApiVersionConvention());
            });

            return services;
        }
    }
}

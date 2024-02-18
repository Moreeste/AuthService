using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Security
{
    public static class ConfigureAuthentication
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfigurationManager configuration)
        {


            return services;
        }
    }
}

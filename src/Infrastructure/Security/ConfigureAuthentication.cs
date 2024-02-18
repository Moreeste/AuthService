using Domain.Model.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Security
{
    public static class ConfigureAuthentication
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfigurationManager configuration)
        {
            var jwt = configuration.GetSection("Jwt").Get<JwtOptions>();

            return services;
        }
    }
}

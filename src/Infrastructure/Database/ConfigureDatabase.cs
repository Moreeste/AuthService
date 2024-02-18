using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database
{
    public static class ConfigureDatabase
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddDbContext<AuthServiceContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AuthServiceDbConexion"));
            });

            return services;
        }
    }
}

using Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureDatabase
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<AuthServiceContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("AuthServiceDbConexion"));
            });

            return services;
        }
    }
}

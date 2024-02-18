using Domain.Model.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.Security
{
    public static class ConfigureAuthentication
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfigurationManager configuration)
        {
            var jwt = configuration.GetSection("Jwt").Get<JwtOptions>();

            if (jwt == null)
            {
                throw new Exception("No se han configurado los valores para el jwt.");
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwt?.Issuer,
                    ValidAudience = jwt?.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt?.Key ?? string.Empty))
                };
            });

            return services;
        }
    }
}

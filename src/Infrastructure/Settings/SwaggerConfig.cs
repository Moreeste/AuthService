using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Infrastructure.Settings
{
    public static class SwaggerConfig
    {
        private const string APPLICATION_NAME = Application.DependencyInjection.ApplicationName;
        private const string SWAGGER = "swagger";
        private const string VERSION_1 = "v1";
        private const string VERSION_2 = "v2";
        private const string JSON = "json";
        private const string AUTHORIZATION = "Authorization";
        private const string BEARER = "Bearer";
        private const string JWT = "JWT";

        public static IServiceCollection AddDefaultSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(VERSION_1, new OpenApiInfo { Title = APPLICATION_NAME, Version = VERSION_1 });
                c.SwaggerDoc(VERSION_2, new OpenApiInfo { Title = APPLICATION_NAME, Version = VERSION_2 });

                c.AddSecurityDefinition(BEARER, new OpenApiSecurityScheme
                {
                    Name = AUTHORIZATION,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = BEARER,
                    BearerFormat = JWT,
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = BEARER
                            }
                        },
                        new string[]{ }
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseDefaultSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{SWAGGER}/{VERSION_1}/{SWAGGER}.{JSON}", $"{APPLICATION_NAME} {VERSION_1}");
                c.SwaggerEndpoint($"/{SWAGGER}/{VERSION_2}/{SWAGGER}.{JSON}", $"{APPLICATION_NAME} {VERSION_2}");
            });

            return app;
        }
    }
}

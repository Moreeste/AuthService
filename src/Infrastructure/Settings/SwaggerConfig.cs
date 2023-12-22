using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Infrastructure.Settings
{
    public static class SwaggerConfig
    {
        private const string ApplicationName = Application.ConfigureServices.ApplicationName;
        private const string Swagger = "swagger";
        private const string Version1 = "v1";
        private const string Version2 = "v2";
        private const string Json = "json";
        private const string Authorization = "Authorization";
        private const string Bearer = "Bearer";
        private const string Jwt = "JWT";

        public static IServiceCollection AddDefaultSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Version1, new OpenApiInfo { Title = ApplicationName, Version = Version1 });
                c.SwaggerDoc(Version2, new OpenApiInfo { Title = ApplicationName, Version = Version2 });

                c.AddSecurityDefinition(Bearer, new OpenApiSecurityScheme
                {
                    Name = Authorization,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = Bearer,
                    BearerFormat = Jwt,
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
                                Id = Bearer
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
                c.SwaggerEndpoint($"/{Swagger}/{Version1}/{Swagger}.{Json}", $"{ApplicationName} {Version1}");
                c.SwaggerEndpoint($"/{Swagger}/{Version2}/{Swagger}.{Json}", $"{ApplicationName} {Version2}");
            });

            return app;
        }
    }
}

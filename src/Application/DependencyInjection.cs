using Application.Auth.Validators;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public const string ApplicationName = "AuthService";

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            services.AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblyContaining<LoginValidator>();
                x.DisableDataAnnotationsValidation = true;
            });

            return services;
        }
    }
}

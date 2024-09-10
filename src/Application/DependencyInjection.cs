using Application.Auth.Services;
using Application.Endpoint.Services;
using Application.Profile.Services;
using Application.ProfilePermissions.Services;
using Application.User.Services;
using Application.UserProperties.Services;
using Application.Validations;
using FluentValidation;
using MediatR;
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
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(assembly);

            services.AddScoped<ICommonValidations, CommonValidations>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IUserPropertiesService, UserPropertiesService>();
            services.AddScoped<IChangePasswordService, ChangePasswordService>();
            services.AddScoped<IEndpointService, EndpointService>();
            services.AddScoped<IProfilePermissionsService, ProfilePermissionsService>();

            return services;
        }
    }
}

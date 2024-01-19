﻿using Application.Auth.Services;
using Application.Register.Services;
using Application.User.Services;
using Domain.Repository;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class CustomServices
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IPasswordService, PasswordService>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

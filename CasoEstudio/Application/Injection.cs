﻿using Application.Identity;
using Application.Articulos;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Injection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ArticuloProfile));
            services.AddValidatorsFromAssemblies(new[] { typeof(CreateArticuloValidator).Assembly });
            
            
            
            
            services.AddScoped<IArticuloService, ArticuloService>();
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }

    }
}
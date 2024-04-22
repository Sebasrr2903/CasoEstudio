using Application.Identity;
using Application.Articulos;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Comentarios;
using Application.Likes;

namespace Application
{
    public static class Injection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ArticuloProfile));
            services.AddValidatorsFromAssemblies(new[] { typeof(CreateArticuloValidator).Assembly });

			services.AddAutoMapper(typeof(ComentarioProfile));
			services.AddValidatorsFromAssemblies(new[] { typeof(CreateComentarioValidator).Assembly });


			services.AddScoped<IArticuloService, ArticuloService>();
			services.AddScoped<IComentarioService, ComentarioService>();
            services.AddScoped<ILikeService, LikeService>();



            services.AddScoped<IIdentityService, IdentityService>();



			return services;
        }

    }
}

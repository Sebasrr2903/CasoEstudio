using Application.Contexts;
using Application.Articulos;
using Domain.Articulos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Comentarios;
using Domain.Comentarios;
using Persistence.Likes;
using Application.Likes;
using Domain.Likes;

namespace Persistence
{
    public static class Injection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IApplicationDbContext>
                (options => options.GetService<ApplicationDbContext>());

            services.AddRepository<Articulo, IArticuloRepository, ArticuloRepository>();

			services.AddRepository<Comentario, IComentarioRepository, ComentarioRepository>();

            services.AddRepository<Like, ILikeRepository, LikeRepository>();


            return services;
        }
    }
}

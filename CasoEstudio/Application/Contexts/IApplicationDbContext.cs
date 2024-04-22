
using Domain.Articulos;
using Domain.Comentarios;
using Domain.Likes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Articulo> Articulos { get; set; }
		DbSet<Comentario> Comentarios { get; set; }

        DbSet<Like> Likes { get; set; }



        void Save();
    }
}
